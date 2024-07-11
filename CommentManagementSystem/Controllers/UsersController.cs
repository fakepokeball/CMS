using Business.Abstract;
using Business.Requests.User;
using Business.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace CommentManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public GetUserListResponse GetList([FromQuery] GetUserListRequest request)
    {
        GetUserListResponse response = _userService.GetList(request);
        return response;
    }

    [HttpGet("{Id}")]
    public GetUserByIdResponse GetById([FromRoute] GetUserByIdRequest request)
    {
        GetUserByIdResponse response = _userService.GetById(request);
        return response;
    }

    [HttpPost]
    public ActionResult<AddUserResponse> Add(AddUserRequest request)
    {
        AddUserResponse response = _userService.Add(request);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id },
            value: response
        );
    }

    [HttpPut("{Id}")]
    public ActionResult<UpdateUserResponse> Update(
        [FromRoute] Guid Id,
        [FromBody] UpdateUserRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateUserResponse response = _userService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public DeleteUserResponse Delete([FromRoute] DeleteUserRequest request)
    {
        DeleteUserResponse response = _userService.Delete(request);
        return response;
    }
}
