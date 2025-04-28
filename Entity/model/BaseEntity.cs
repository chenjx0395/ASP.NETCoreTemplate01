namespace Entity.model
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
