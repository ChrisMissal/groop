using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Groop.Core;

namespace Groop.Data
{
    public class XmlRepository : IXmlRepository
    {
        public IPathResolver PathResolver { get; set; }
        private readonly string fileLocation;
        private readonly IPathResolver pathResolver;
        private readonly XDocument document;
        private readonly IDictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();

        public XmlRepository(string fileLocation, ISerializationProvider serializationProvider, IPathResolver pathResolver)
        {
            PathResolver = pathResolver;
            this.fileLocation = pathResolver.Resolve(fileLocation);
            this.pathResolver = pathResolver;

            InitializeFile(this.fileLocation);

            document = XDocument.Load(this.fileLocation);

            foreach (var serializer in serializationProvider.XmlSerializers)
            {
                var type = serializer.Type;
                serializers.Add(type, serializer);
            }
            Initialize(document, serializers.Select(x => x.Key));
            document.Save(this.fileLocation);
        }

        public event EventHandler ItemAddedEventHandler = (o, e) => { };

        public event EventHandler ItemUpdatedEventHandler = (o, e) => { };

        public event EventHandler DataChangedEventHandler = (o, e) => { };

        public T Get<T>(int id) where T : class
        {
            var node = GetElement<T>(id);

            return node == null ? default(T) : Deserialize<T>(node);
        }

        public IList<T> GetAll<T>() where T : class
        {
            var items = new List<T>();

            var parent = GetParentElementFor<T>();

            if(parent == null)
                throw MissingParentForTypeException<T>();

            var children = parent.Descendants(typeof (T).Name);

            foreach (var child in children)
                items.Add(Deserialize<T>(child));

            return items;
        }

        public virtual void Add<T>(T obj, Action<T, int> setAction) where T : class
        {
            var element = GetParentElementFor<T>();

            var id = GetNextID<T>(element);

            setAction(obj, id);
            
            element.Add(Serialize(obj));
            document.Save(fileLocation);

            InvokeItemAddedEventHandler(obj);
        }

        public void Update<T>(T obj, int id) where T : class
        {
            var saved = Get<T>(id);

            if (saved == null)
                throw new InvalidOperationException("Unable to update an object that hasn't been saved.");

            var savedNode = GetElement<T>(id);
            savedNode.ReplaceWith(Serialize(obj));
            document.Save(fileLocation);

            InvokeItemUpdatedEventHandler(new ItemUpdatedEventArgs<T>(obj));
        }

        private static int GetNextID<T>(XContainer element)
        {
            if (element == null)
                throw MissingParentForTypeException<T>();

            return element.Nodes().Count() + 1;
        }

        private static InvalidOperationException MissingParentForTypeException<T>()
        {
            return new InvalidOperationException(string.Format("There is no parent node for type : {0}", typeof(T).FullName));
        }

        private XElement GetParentElementFor<T>()
        {
            var root = document.Root;

            return root.Element(ParentName<T>());
        }

        private XElement GetElement<T>(int id)
        {
            var parent = GetParentElementFor<T>();

            if (parent == null)
                throw MissingParentForTypeException<T>();

            return parent.Elements()
                .FirstOrDefault(e => e.Element(Id<T>()).Value == id.ToString());
        }

        private XNode Serialize<T>(T source)
        {
            var target = new XDocument();
            
            using(var writer = target.CreateWriter())
            {
                serializers[typeof(T)].Serialize(writer, source);
                writer.Close();
            }

            InvokeDataChangedEventHandler(source);
            
            return target.Document.FirstNode;
        }

        private T Deserialize<T>(XNode node)
        {
            var reader = node.CreateReader();
            var obj = serializers[typeof(T)].Deserialize(reader);

            return (T)obj;
        }

        private void InitializeFile(string location)
        {
            var fileInfo = new FileInfo(location);

            if(fileInfo.Exists)
                return;

            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            using (var writer = fileInfo.CreateText())
            {
                var rootName = GetType().Namespace.Replace(".", "-").ToLowerInvariant();
                writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?><{0}/>", rootName);
                writer.Flush();
            }
        }

        private static void Initialize(XDocument xDocument, IEnumerable<Type> types)
        {
            foreach (var parentName in types.Select(x => ParentName(x)))
                if (!xDocument.Root.Elements(XName.Get(parentName)).Any())
                    xDocument.Root.Add(new XElement(parentName));
        }

        private static string Id<T>()
        {
            return typeof (T).Name + "Id";
        }

        private static string ParentName<T>()
        {
            return ParentName(typeof (T));
        }

        public static string ParentName(Type type)
        {
            var name = type.Name;
            if (name.EndsWith("y", StringComparison.InvariantCultureIgnoreCase))
                return name.Remove(name.Length - 1, 1) + "ies";

            return name + "s";
        }

        private void InvokeItemAddedEventHandler<T>(T item)
        {
            var handler = ItemAddedEventHandler;
            if (handler != null) handler(this, new ItemAddedEventArgs<T>(item));
        }

        private void InvokeItemUpdatedEventHandler<T>(T item)
        {
            var handler = ItemUpdatedEventHandler;
            if (handler != null) handler(this, new ItemUpdatedEventArgs<T>(item));
        }

        private void InvokeDataChangedEventHandler<T>(T item)
        {
            var handler = DataChangedEventHandler;
            if (handler != null) handler(this, new DataChangedEventArgs<T>(item));
        }
    }
}