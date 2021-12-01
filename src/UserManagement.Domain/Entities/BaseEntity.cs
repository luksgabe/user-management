namespace UserManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual bool Active { get; set; }
    }
}
