using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class ObjectiveBusinessRules
    {
        private readonly IObjectiveDal _objectiveDal;

        public ObjectiveBusinessRules(IObjectiveDal objectiveDal)
        {
            _objectiveDal = objectiveDal;
        }

        public void CheckIfObjectiveHasDuplicates(string title, string description)
        {
            bool isExists = _objectiveDal.Get(obj => obj.Title == title && obj.Description == description) is not null;
            if (isExists)
            {
                throw new Exception("Objective already exists.");
            }
        }
        public void CheckIfObjectiveExists(Objective objective)
        {
            if (objective is null)
                throw new NotFoundException("Objective not found."); ;
        }
    }
}
