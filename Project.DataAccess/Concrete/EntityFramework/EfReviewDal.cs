using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EfReviewDal : EfEntityRepository<Review>, IReviewDal
    {
        public EfReviewDal(AppDataContext context) : base(context)
        {
        }
    }
}
