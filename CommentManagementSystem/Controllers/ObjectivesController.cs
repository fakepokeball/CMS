using Business.Abstract;
using Business.Requests.Objective;
using Business.Responses.Objective;
using Microsoft.AspNetCore.Mvc;

namespace CommentManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObjectivesController : ControllerBase
{
     private readonly IObjectiveService _objectiveService;

    public ObjectivesController(IObjectiveService objectiveService)
    {
        _objectiveService = objectiveService;
    }

    [HttpGet] 
    public GetObjectiveListResponse GetList([FromQuery] GetObjectiveListRequest request)
    {
        GetObjectiveListResponse response = _objectiveService.GetList(request);
        return response;
    }

    [HttpGet("{Id}")] 
    public GetObjectiveByIdResponse GetById([FromRoute] GetObjectiveByIdRequest request)
    {
        GetObjectiveByIdResponse response = _objectiveService.GetById(request);
        return response;
    }

    [HttpPost] 
    public ActionResult<AddObjectiveResponse> Add(AddObjectiveRequest request)
    {
        AddObjectiveResponse response = _objectiveService.Add(request);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id },
            value: response 
        );
    }

    [HttpPut("{Id}")]
    public ActionResult<UpdateObjectiveResponse> Update(
        [FromRoute] Guid Id,
        [FromBody] UpdateObjectiveRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateObjectiveResponse response = _objectiveService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public DeleteObjectiveResponse Delete([FromRoute] DeleteObjectiveRequest request)
    {
        DeleteObjectiveResponse response = _objectiveService.Delete(request);
        return response;
    }
}
