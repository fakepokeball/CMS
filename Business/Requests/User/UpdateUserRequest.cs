namespace Business.Requests.User
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}