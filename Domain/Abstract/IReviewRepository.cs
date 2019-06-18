using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        void SaveReview(Review review);
        Review DeleteReview(int reviewId);
    }
}
