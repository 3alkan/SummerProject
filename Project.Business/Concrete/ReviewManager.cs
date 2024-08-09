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

        public List<Review> GetAll(Expression<Func<Review, bool>> filter = null, List<Expression<Func<Review, object>>> includes = null)
        {
            return _reviewDal.GetAll(filter,includes);
        }

        public Review Get(Expression<Func<Review, bool>> filter, List<Expression<Func<Review, object>>> includes = null)
        {
            return _reviewDal.Get(filter,includes);
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