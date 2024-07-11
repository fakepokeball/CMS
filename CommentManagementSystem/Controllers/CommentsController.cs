using Business.Abstract;
using Business.Requests.Comment;
using Business.Responses.Comment;
using Microsoft.AspNetCore.Mvc;

namespace CommentManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public GetCommentListResponse GetList([FromQuery] GetCommentListRequest request)
    {
        GetCommentListResponse response = _commentService.GetList(request);
        return response;
    }

    [HttpGet("{Id}")]
    public GetCommentByIdResponse GetById([FromRoute] GetCommentByIdRequest request)
    {
        GetCommentByIdResponse response = _commentService.GetById(request);
        return response;
    }

    [HttpPost]
    public ActionResult<AddCommentResponse> Add(AddCommentRequest request)
    {
        AddCommentResponse response = _commentService.Add(request);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id },
            value: response
        );
    }

    [HttpPut("{Id}")]
    public ActionResult<UpdateCommentResponse> Update(
        [FromRoute] Guid Id,
        [FromBody] UpdateCommentRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateCommentResponse response = _commentService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public DeleteCommentResponse Delete([FromRoute] DeleteCommentRequest request)
    {
        DeleteCommentResponse response = _commentService.Delete(request);
        return response;
    }
}
