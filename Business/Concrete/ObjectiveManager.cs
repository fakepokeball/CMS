using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Objective;
using Business.Responses.Objective;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ObjectiveManager : IObjectiveService
{
    private readonly IObjectiveDal _objectiveDal;
    private readonly IMapper _mapper;
    private readonly ObjectiveBusinessRules _objectiveBusinessRules;


    public ObjectiveManager(IObjectiveDal objectiveDal, IMapper mapper, ObjectiveBusinessRules objectiveBusinessRules)
    {
        _objectiveDal = objectiveDal;
        _mapper = mapper;
        _objectiveBusinessRules = objectiveBusinessRules;
    }

    public GetObjectiveListResponse GetList(GetObjectiveListRequest request)
    {
        IList<Objective> objectiveList = _objectiveDal.GetList();

        GetObjectiveListResponse response = _mapper.Map<GetObjectiveListResponse>(objectiveList);

        return response;
    }

    public GetObjectiveByIdResponse GetById(GetObjectiveByIdRequest request)
    {
        Objective? objective = _objectiveDal.Get(predicate: objective => objective.Id == request.Id);

        _objectiveBusinessRules.CheckIfObjectiveExists(objective);

        var response = _mapper.Map<GetObjectiveByIdResponse>(objective);

        return response;
    }

    public AddObjectiveResponse Add(AddObjectiveRequest request)
    {
        
        _objectiveBusinessRules.CheckIfObjectiveHasDuplicates(request.Title, request.Description);

        Objective? objectiveToAdd = _mapper.Map<Objective>(request);

        Objective addedObjective = _objectiveDal.Add(objectiveToAdd);

        AddObjectiveResponse response = _mapper.Map<AddObjectiveResponse>(addedObjective);

        return response;
    }

    public UpdateObjectiveResponse Update(UpdateObjectiveRequest request)
    {
        Objective? objectiveToUpdate = _objectiveDal.Get(predicate: objective => objective.Id == request.Id);

        _objectiveBusinessRules.CheckIfObjectiveExists(objectiveToUpdate);


        objectiveToUpdate = _mapper.Map(request, objectiveToUpdate);

        Objective updatedObjective = _objectiveDal.Update(objectiveToUpdate!);

        UpdateObjectiveResponse response = _mapper.Map<UpdateObjectiveResponse>(
            updatedObjective
        );

        return response;
    }

    public DeleteObjectiveResponse Delete(DeleteObjectiveRequest request)
    {
        Objective? objectiveToDelete = _objectiveDal.Get(predicate: objective => objective.Id == request.Id);

        _objectiveBusinessRules.CheckIfObjectiveExists(objectiveToDelete);

        Objective deletedObjective = _objectiveDal.Delete(objectiveToDelete!);

        DeleteObjectiveResponse response = _mapper.Map<DeleteObjectiveResponse>(
            deletedObjective
        );

        return response;
    }
}
