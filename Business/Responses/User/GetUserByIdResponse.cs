namespace Business.Responses.User
{
    public class GetUserByIdResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}