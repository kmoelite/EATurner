using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Html;
using EATurnerDataBackend.Repositories;
using EATurnerDataBackend.ServiceModel.RequestDTOs;
using EATurnerDataBackend.ServiceModel.ResponseDTOs;
using System.Threading.Tasks;

namespace EATurnerDataBackend.Services
{
    public class TitleService : Service, IService
    {
        private readonly TitleRepository _titleRepository;

        public TitleService()
        {
            _titleRepository = new TitleRepository();
        }

        [Route("/search/{SearchText}")]
        public MovieSearchResponse Any(MovieSearchRequest request)
        {
            var response = new MovieSearchResponse();
            var errors = new List<string>();

            try
            {
                response = _titleRepository.GetMovieInfo(request);
                return response;
            }
            catch (Exception ex)
            {
                return new MovieSearchResponse { Error = String.Format("An error has occurred. Details: {0} **StackTrace** {1}", ex.Message, ex.StackTrace.ToString()) };
            }
        }

        [Route("/searchDetail/{TitleId}")]
        public DetailSearchResponse Any(DetailSearchRequest request)
        {
            var response = new DetailSearchResponse();
            var errors = new List<string>();

            try
            {
                response = _titleRepository.GetMovieDetailInfo(request);
                return response;
            }
            catch (Exception ex)
            {
                return new DetailSearchResponse { Error = String.Format("An error has occurred. Details: {0} **StackTrace** {1}", ex.Message, ex.StackTrace.ToString()) };
            }
        }
    }
}