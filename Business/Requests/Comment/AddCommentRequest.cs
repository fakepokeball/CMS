namespace Business.Requests.Comment
{
    public class AddCommentRequest
    {
        public Guid ObjectiveId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}