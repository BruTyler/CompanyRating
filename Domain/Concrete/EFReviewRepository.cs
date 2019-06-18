using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFReviewRepository : IReviewRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Review> Reviews
        {
            get { return context.Reviews; }
        }

        public Review DeleteReview(int reviewId)
        {
            var dbEntry = context.Reviews.Find(reviewId);

            if (dbEntry != null)
            {
                context.Reviews.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveReview(Review review)
        {
            if (review.ReviewID == 0)
            {
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews.Find(review.ReviewID);
                if (dbEntry != null)
                {
                    dbEntry.PositiveMoment = review.PositiveMoment;
                    dbEntry.NegativeMoment = review.NegativeMoment;
                    dbEntry.Comment = review.Comment;
                }
            }
            context.SaveChanges();
        }
    }
}
