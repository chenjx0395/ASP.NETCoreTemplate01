namespace Entity.model
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime EditDate { get; set; }  = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}
