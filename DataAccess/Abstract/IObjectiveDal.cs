using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface IObjectiveDal : IEntityRepository<Entities.Concrete.Objective, Guid>
    {
    }
}
