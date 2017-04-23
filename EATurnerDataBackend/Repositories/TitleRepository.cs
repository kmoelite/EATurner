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
                var awards = new List<AwardData>();
                var genres = new List<Genre>();
                var othernames = new List<OtherName>();
                var participants = new List<Participant>();
                var storylines = new List<StoryLine>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["TitleDBConnectionString"]))
                {
                    titles = conn.Query<Title>("SELECT * FROM Titles.dbo.Title WHERE TitleId = " + request.TitleId).ToList();
                    awards = conn.Query<AwardData>("SELECT * FROM Titles.dbo.Award WHERE TitleId = " + request.TitleId).ToList();
                    genres = conn.Query<Genre>(" SELECT g.* FROM Titles.dbo.Title t" +
                                                 " JOIN Titles.dbo.TitleGenre tg ON t.TitleId = tg.TitleId" +
                                                 " JOIN Titles.dbo.Genre g ON tg.GenreId = g.Id" +
                                                 " WHERE t.TitleId =" + request.TitleId).ToList();
                    othernames = conn.Query<OtherName>("SELECT * FROM Titles.dbo.OtherName WHERE TitleId = " + request.TitleId).ToList();
                    storylines = conn.Query<StoryLine>("SELECT * FROM Titles.dbo.StoryLine WHERE TitleId = " + request.TitleId).ToList();
                    participants = conn.Query<Participant>(" SELECT p.* FROM Titles.dbo.Title t" +
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