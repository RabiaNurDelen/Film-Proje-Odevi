using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class MovieController : ApiController
    {
        DatabaseOperations.MoviesOperations mo = new DatabaseOperations.MoviesOperations();

        [HttpGet]
        public DatabaseOperations.MoviesOperations.UsersRec UserControl(string email, string pass)
        {
            return mo.userControl(email, pass);
        }

        [HttpGet]
        public List<DatabaseOperations.MoviesOperations.MovieRec> GetAllMovies()
        {
            return mo.GetAllMovies();
        }

        [HttpGet]
        public List<DatabaseOperations.MoviesOperations.MovieRec> GetAllMoviesByCategory(int CategoryID)
        {
            return mo.GetAllMoviesByCategory(CategoryID);
        }

        [HttpGet]
        public DatabaseOperations.MoviesOperations.MovieRec GetMovie(int MovieID)
        {
            return mo.GetMovie(MovieID);
        }

        [HttpGet]
        public List<DatabaseOperations.MoviesOperations.MovieRec> DeleteMovie(int MovieID)
        {
            return mo.DeleteMovie(MovieID);
        }
    }
}