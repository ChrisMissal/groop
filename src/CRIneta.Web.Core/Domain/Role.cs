namespace CRIneta.Web.Core.Domain
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }
    }

    public class Entity<T>
    {
        public T Id { get; set;}
    }
}