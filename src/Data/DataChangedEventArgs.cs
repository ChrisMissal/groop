namespace Groop.Data
{
    public class DataChangedEventArgs<T> : XmlRepositoryEventArgs<T>
    {
        public DataChangedEventArgs(T item) : base(item)
        {
        }
    }
}