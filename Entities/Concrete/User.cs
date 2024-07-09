using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class User : Entity<Guid>
    {
        public string Email { get; set; }
        public string Username { get; set; }

        public User()
        {
            
        }

        public User(string email, string username)
        {
            Email = email;
            Username = username;
        }

        public ICollection<Comment> Comments { get; set; }

    }
}
