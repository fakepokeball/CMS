using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, Guid, AppDbContext>, IUserDal
    {
        public EfUserDal(AppDbContext context) : base(context)
        {
        }
    }
}
