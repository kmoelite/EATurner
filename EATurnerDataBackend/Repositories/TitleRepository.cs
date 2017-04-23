using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using EATurnerDataBackend.ServiceModel;
using EATurnerDataBackend.ServiceModel.RequestDTOs;
using EATurnerDataBackend.ServiceModel.ResponseDTOs;
using Dapper;
using System.Data;
using ServiceStack;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EATurnerDataBackend.Repositories
{
    public class TitleRepository
    {

        public MovieSearchResponse GetMovieInfo(MovieSearchRequest request)
        {
            try
            {
                var response = new MovieSearchResponse();
                response.Error = string.Empty;
                var movie = new Movie();
                var titles = new List<Title>();
                string connString = ConfigurationManager.AppSettings["TitleDBConnectionString"];
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    titles = conn.Query<Title>("SELECT * FROM Titles.dbo.Title WHERE TitleName LIkE '%" + request.SearchText + "%'").ToList();
                }

                movie.Titles = titles;
                response.Movie = movie;
                return response;
            }
            catch (Exception ex)
            {
                return new MovieSearchResponse { Error = String.Format("An error has occurred. Details: {0} **StackTrace** {1}", ex.Message, ex.StackTrace.ToString()) };
            }
        }

        public DetailSearchResponse GetMovieDetailInfo(DetailSearchRequest request)
        {
            try
            {
                var response = new DetailSearchResponse();
                response.Error = string.Empty;
                var movie = new Movie();
                var titles = new List<Title>();
                var awards = new List<Award>();
                var genres = new List<Genre>();
                var othernames = new List<OtherName>();
                var participants = new List<Participant>();
                var storylines = new List<StoryLine>();
                var titleGenres = new List<TitleGenre>();
                var titleParticipants = new List<TitleParticipant>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["TitleDBConnectionString"]))
                {
                    titles = conn.Query<Title>("SELECT * FROM Titles.dbo.Title WHERE TitleId = " + request.TitleId).ToList();
                    awards = conn.Query<Award>("SELECT * FROM Titles.dbo.Award WHERE TitleId = " + request.TitleId).ToList();
                    //genres = conn.Query<Genre>("SELECT * FROM Titles.dbo.Title WHERE TitleId = " + request.TitleId).ToList();
                    //othernames = conn.Query<OtherName>("SELECT * FROM Titles.dbo.Title WHERE TitleId = " + request.TitleId).ToList();
                    storylines = conn.Query<StoryLine>("SELECT * FROM Titles.dbo.Title WHERE TitleId = " + request.TitleId).ToList();
                    //titleGenres = conn.Query<TitleGenre>("SELECT * FROM Titles.dbo.Title WHERE TitleId = " + request.TitleId).ToList();
                    titleParticipants = conn.Query<TitleParticipant>(" SELECT p.* FROM Titles.dbo.Title t" +
                                                                         " JOIN Titles.dbo.TitleParticipant tp ON t.TitleId = tp.TitleId" +
                                                                         " JOIN Titles.dbo.Participant p ON tp.ParticipantId = p.Id" +
                                                                         " WHERE t.TitleId = " + request.TitleId).ToList();
                }

                movie.Titles = titles;
                movie.Awards = awards;
                movie.Genres = genres;
                movie.OtherNames = othernames;
                movie.Actors = participants;
                movie.StoryLines = storylines;
                movie.TitleGenres = titleGenres;
                movie.TitleParticipants = titleParticipants;

                response.Movie = movie;
                return response;
            }
            catch (Exception ex)
            {
                return new DetailSearchResponse { Error = String.Format("An error has occurred. Details: {0} **StackTrace** {1}", ex.Message, ex.StackTrace.ToString()) };
            }
        }

    }
}