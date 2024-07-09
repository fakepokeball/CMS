using Business.Requests.Comment;
using Business.Responses.Comment;

namespace Business.Abstract
{
    public interface ICommentService
    {
        public AddCommentResponse Add(AddCommentRequest request);

        public GetCommentListResponse GetList(GetCommentListRequest request);

        public GetCommentByIdResponse GetById(GetCommentByIdRequest request);
        public UpdateCommentResponse Update(UpdateCommentRequest request);
        public DeleteCommentResponse Delete(DeleteCommentRequest request);
    }
}
