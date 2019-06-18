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
    public class ReviewController : Controller
    {
        private IReviewRepository repository;
        public int PageSize = 5;

        public ReviewController(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult List(int? page = 1)
        {
            var currentPage = page ?? 1;
            ReviewsListViewModel reviewModel = new ReviewsListViewModel
            {
                Reviews = repository.Reviews
            };
            var resultReviews = reviewModel.GetReviewsOnPage(ref currentPage, ref PageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ReviewRow", resultReviews);
            }
            return View(resultReviews);
        }

        public ViewResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(Review review)
        {
            if (ModelState.IsValid)
            {
                repository.SaveReview(review);
                TempData["message"] = $"Отзыв о компании \"{review.Company}\" был сохранен";
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Detail(int? reviewId, string returnUrl)
        {
            if(reviewId == null)
                return RedirectToAction("List");

            ReviewDetail model = new ReviewDetail()
            {
                Review = repository.Reviews.FirstOrDefault(x => x.ReviewID == reviewId) ?? new Review(),
                ReturnUrl = returnUrl
            };

            return View(model);
        }

    }
}