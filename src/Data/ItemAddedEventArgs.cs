namespace Groop.Data
{
    public class ItemAddedEventArgs<T> : XmlRepositoryEventArgs<T>
    {
        public ItemAddedEventArgs(T item) : base(item)
        {
        }
    }
}