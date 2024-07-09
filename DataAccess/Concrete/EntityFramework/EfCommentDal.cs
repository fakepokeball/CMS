using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, Guid, AppDbContext>, ICommentDal
    {
        public EfCommentDal(AppDbContext context) : base(context)
        {
        }
    }
}
