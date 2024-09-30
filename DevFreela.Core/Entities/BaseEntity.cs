namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DateCreated = DateTime.Now;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
