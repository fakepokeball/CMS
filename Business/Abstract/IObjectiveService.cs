using Business.Requests.Objective;
using Business.Responses.Objective;

namespace Business.Abstract
{
    public interface IObjectiveService
    {
        public AddObjectiveResponse Add(AddObjectiveRequest request);

        public GetObjectiveListResponse GetList(GetObjectiveListRequest request);

        public GetObjectiveByIdResponse GetById(GetObjectiveByIdRequest request);
        public UpdateObjectiveResponse Update(UpdateObjectiveRequest request);
        public DeleteObjectiveResponse Delete(DeleteObjectiveRequest request);
    }
}
