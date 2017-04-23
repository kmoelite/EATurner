using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack;
using EATurnerDataService.ServiceModel.RequestDTOs;
using EATurnerDataService.ServiceModel.ResponseDTOs;

namespace EATurnerDataService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //SPA (Single Page Application) Application
            ViewBag.Title = "Find Titles, Media, and More";
            return View();
        }

        [HttpPost]
        public ActionResult GetMovie(string movieSearchText)
        {
            try
            {
                var client = ServiceStackClient.GetClient();
                var request = new MovieSearchRequest();
                request.SearchText = movieSearchText;
                var response = new MovieSearchResponse();
                response = client.Post(request);
                return PartialView("Search/MovieInitialSearch", response.Movie);
            }
            catch (Exception ex)
            {
                return PartialView("Search/MovieInitialSearch", new MovieSearchResponse {Error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult GetMovieDetails(int titleId)
        {
            try
            {
                var client = ServiceStackClient.GetClient();
                var request = new DetailSearchRequest();
                request.TitleId = titleId;
                var response = new DetailSearchResponse();
                response = client.Post(request);
                return PartialView("Search/MovieDetailSearch", response.Movie);
            }
            catch (Exception ex)
            {
                return PartialView("Search/MovieDetailSearch", new DetailSearchResponse { Error = ex.Message });
            }
        }
    }
}
