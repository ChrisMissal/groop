namespace CRIneta.Web.Core.Domain
{
    public class Role : Entity<int>
    {
        public virtual string Name { get; set; }
    }

    public class Entity<T>
    {
        public virtual T Id { get; set;}
    }
}