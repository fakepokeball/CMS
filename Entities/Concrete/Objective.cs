using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Objective : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Objective()
        {
            
        }

        public Objective(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public ICollection<Comment> Comments { get; set; }
    }
}
