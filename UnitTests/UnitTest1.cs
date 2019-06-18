using System;
using System.Linq;
using System.Web.Mvc;
using CompanyRating.Controllers;
using CompanyRating.HtmlHelpers;
using CompanyRating.Models;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CompanyRating.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 12,
                ItemsPerPage = 5
            };

            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(),
                @"<a href=""Page1"">1</a>"
            + @"<a class=""selected"" href=""Page2"">2</a>"
            + @"<a href=""Page3"">3</a>");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(m => m.Reviews).Returns(new Review[] {
                new Review {ReviewID = 1, Company = "C1", Person="P1", Mark= 1 },
                new Review {ReviewID = 2, Company = "C2", Person="P2", Mark= 2 },
                new Review {ReviewID = 3, Company = "C3", Person="P3", Mark= 3 },
                new Review {ReviewID = 4, Company = "C4", Person="P4", Mark= 4 },
                new Review {ReviewID = 5, Company = "C5", Person="P5", Mark= 5 }
            }.AsQueryable());

            ReviewController controller = new ReviewController(mock.Object);
            controller.PageSize = 3;
            ReviewsListViewModel result = (ReviewsListViewModel) controller.List(2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
