using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Comment : Entity<Guid>
    {
        public Guid ObjectiveId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;

        public Comment()
        {
            
        }

        public Comment(Guid ObjectiveId, Guid userId, string content)
        {
            ObjectiveId = ObjectiveId;
            UserId = userId;
            Content = content;
        }

        public Objective Objective { get; set; }
        public User User { get; set; }
    }
}
