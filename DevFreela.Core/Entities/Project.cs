using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        protected Project()
        {
            
        }
        public Project(string description, string title, int idClient, int idFreelancer,  decimal totalCost) : base()
        {
            Description = description;
            Title = title;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            Status = ProjectStatusEnum.Created;
            Comments = [];
        }

        public string Description { get; private set; }
        public string Title { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Client { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.Canceled;
            }
        }

        public void Start() 
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }
        public void Complete() 
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.PayementPending)
            {
                Status = ProjectStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }
        public void SetPayementPending() 
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.PayementPending;
            }
        }
        public void Update(string title, string description, decimal totalCost) 
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
