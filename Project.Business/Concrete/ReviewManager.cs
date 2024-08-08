using System.Linq.Expressions;
using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.Business.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly IReviewDal _reviewDal;
        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public void Add(Review review)
        {
            _reviewDal.Add(review);
        }

        public void Delete(Review review)
        {
            _reviewDal.Delete(review);
        }

        public Review Get(Expression<Func<Review, bool>> filter)
        {
            return _reviewDal.Get(filter);
        }

        public List<Review> GetAll(Expression<Func<Review, bool>> filter = null)
        {
            return _reviewDal.GetAll(filter);
        }

        public Review GetById(int id)
        {
            return _reviewDal.GetById(id);
        }

        public void Update(Review review)
        {
            _reviewDal.Update(review);
        }
    }
}