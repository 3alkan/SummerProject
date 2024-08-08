using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Project.Business.Abstract
{
    public interface IReviewService
    {
        void Add(Review review);
        void Update(Review review);
        void Delete(Review review);
        Review GetById(int id);
        List<Review> GetAll(Expression<Func<Review, bool>> filter = null);
        Review Get(Expression<Func<Review, bool>> filter);
    }
}
