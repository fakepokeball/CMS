namespace Business.Responses.Comment
{
    public class GetCommentListResponse
    {
        public Guid Id { get; set; }
        public Guid ObjectiveId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}