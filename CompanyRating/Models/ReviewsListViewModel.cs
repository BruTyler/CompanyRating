using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyRating.Models
{
    public class ReviewsListViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public IEnumerable<Review> GetReviewsOnPage(ref int page, ref int pageSize)
        {
            return Reviews
                    .OrderByDescending(p => p.ReviewID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }
    }
}