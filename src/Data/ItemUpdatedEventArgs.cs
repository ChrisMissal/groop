namespace Groop.Data
{
    public class ItemUpdatedEventArgs<T> : XmlRepositoryEventArgs<T>
    {
        public ItemUpdatedEventArgs(T item) : base(item)
        {
        }
    }
}