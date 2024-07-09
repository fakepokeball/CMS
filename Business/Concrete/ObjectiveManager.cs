using AutoMapper;
using Business.Abstract;
using Business.Requests.Objective;
using Business.Responses.Objective;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ObjectiveManager : IObjectiveService
    {
        private readonly IObjectiveDal _objectiveDal;
        private readonly IMapper _mapper;


        public ObjectiveManager(IObjectiveDal objectiveDal, IMapper mapper)
        {
            _objectiveDal = objectiveDal;
            _mapper = mapper;
        }

        public GetObjectiveListResponse GetAll(GetObjectiveListRequest request) 
        {
            IList<Objective> objectiveList = _objectiveDal.GetList();

            GetObjectiveListResponse response = _mapper.Map<GetObjectiveListResponse>(objectiveList);

            return response;
        }
        public GetObjectiveByIdResponse GetById(GetObjectiveByIdRequest request)
        {
            Objective? model = _modelDal.Get(predicate: model => model.Id == request.Id);
            _modelBusinessRules.CheckIfObjectiveExists(model);

            var response = _mapper.Map<GetModelByIdResponse>(model);
            return response;
        }
    }
}
