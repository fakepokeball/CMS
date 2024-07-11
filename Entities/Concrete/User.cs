using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class User : Entity<Guid>
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public User()
        {
            
        }

        public User(string email, string username)
        {
            Email = email;
            UserName = username;
        }

        public ICollection<Comment> Comments { get; set; }

    }
}
