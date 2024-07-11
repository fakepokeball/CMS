namespace Business.Responses.User
{
    public class UpdateUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}