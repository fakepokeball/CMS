namespace Business.Requests.Comment
{
    public class GetCommentListRequest
    {
        public Guid? FilterByObjectiveId { get; set; }
        public Guid? FilterByUserId { get; set; }
    }
}