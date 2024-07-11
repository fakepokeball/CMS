using AutoMapper;
using Business.Requests.Comment;
using Business.Responses.Comment;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CommentManager
{
    private readonly ICommentDal _commentDal;
    private readonly IMapper _mapper;

    public CommentManager(ICommentDal commentDal, IMapper mapper)
    {
        _commentDal = commentDal;
        _mapper = mapper;        
    }

    public GetCommentListResponse GetList(GetCommentListRequest request)
    {
        IList<Comment> commentList = _commentDal.GetList();

        GetCommentListResponse response = _mapper.Map<GetCommentListResponse>(commentList);

        return response;
    }

    public GetCommentByIdResponse GetById(GetCommentByIdRequest request)
    {
        Comment? comment = _commentDal.Get(predicate: comment => comment.Id == request.Id);

        var response = _mapper.Map<GetCommentByIdResponse>(comment);

        return response;
    }

    public AddCommentResponse Add(AddCommentRequest request)
    {
        Comment? commentToAdd = _mapper.Map<Comment>(request);

        Comment addedComment = _commentDal.Add(commentToAdd);

        AddCommentResponse response = _mapper.Map<AddCommentResponse>(addedComment);

        return response;
    }

    public UpdateCommentResponse Update(UpdateCommentRequest request)
    {
        Comment? commentToUpdate = _commentDal.Get(predicate: comment => comment.Id == request.Id);

        commentToUpdate = _mapper.Map(request, commentToUpdate);

        Comment updatedComment = _commentDal.Update(commentToUpdate!);

        UpdateCommentResponse response = _mapper.Map<UpdateCommentResponse>(
            updatedComment
        );

        return response;
    }

    public DeleteCommentResponse Delete(DeleteCommentRequest request)
    {
        Comment? commentToDelete = _commentDal.Get(predicate: comment => comment.Id == request.Id);

        Comment deletedComment = _commentDal.Delete(commentToDelete!);

        DeleteCommentResponse response = _mapper.Map<DeleteCommentResponse>(
            deletedComment
        );

        return response;
    }
}
