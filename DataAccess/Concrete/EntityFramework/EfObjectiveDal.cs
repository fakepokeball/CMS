using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfObjectiveDal : EfEntityRepositoryBase<Entities.Concrete.Objective,Guid,AppDbContext>, IObjectiveDal
    {
        public EfObjectiveDal(AppDbContext context) : base(context)
        {
            
        }
    }
}
