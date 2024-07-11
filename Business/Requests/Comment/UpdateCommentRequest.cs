namespace Business.Requests.Comment
{
    public class UpdateCommentRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}