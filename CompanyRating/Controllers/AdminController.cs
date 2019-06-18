using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using CompanyRating.Models;

namespace CompanyRating.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IReviewRepository repository;
        public int PageSize = 5;

        public AdminController(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(int page = 1)
        {
            ReviewsListViewModel model = new ReviewsListViewModel
            {
                Reviews = repository.Reviews
                    .OrderByDescending(p => p.ReviewID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Reviews.Count()
                }
            };

            return View(model);
        }


        public ActionResult Delete(int reviewId)
        {
            var deletedReview = repository.DeleteReview(reviewId);
            if (deletedReview != null)
            {
                TempData["message"] = $"Отзыв №{deletedReview.ReviewID} о компании \"{deletedReview.Company}\" был успешно удален";
            }
            return RedirectToAction("List");
        }
    }
}