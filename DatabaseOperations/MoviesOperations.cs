using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperations
{
    public class MoviesOperations
    {
        moviesEntities _ent = new moviesEntities();

        public List<MovieRec> GetAllMovies()
        {
            return _ent.movieList.OrderByDescending(p => p.date).Select(p => new MovieRec() {
                id = p.id,
                title = p.title,
                description = p.description,
                imageUrl = p.imageUrl,
                videoUrl = p.videoUrl,
                categoryId = p.categoryId,
                date = p.date,
                categoryName = p.categoryName,
                lang_suntitle = p.lang_suntitle,
                year = p.year,
                imdb = p.imdb
            }).ToList();
        }

        public List<MovieRec> GetAllMoviesByCategory(int CategoryID)
        {
            return _ent.movieList.Where(p => p.categoryId == CategoryID).OrderByDescending(p => p.date).Select(p => new MovieRec()
            {
                id = p.id,
                title = p.title,
                description = p.description,
                imageUrl = p.imageUrl,
                videoUrl = p.videoUrl,
                categoryId = p.categoryId,
                date = p.date,
                categoryName = p.categoryName,
                lang_suntitle = p.lang_suntitle,
                year = p.year,
                imdb = p.imdb
            }).ToList();
        }

        public MovieRec GetMovie( int MovieID )
        {
            return _ent.movieList.Where(p => p.id == MovieID).Select(p => new MovieRec()
            {
                id = p.id,
                title = p.title,
                description = p.description,
                imageUrl = p.imageUrl,
                videoUrl = p.videoUrl,
                categoryId = p.categoryId,
                date = p.date,
                categoryName = p.categoryName,
                lang_suntitle = p.lang_suntitle,
                year = p.year,
                imdb = p.imdb
            }).FirstOrDefault();
        }

        public List<MovieRec> DeleteMovie( int MovieID )
        {
            movies deletedMovie = _ent.movies.Find( MovieID );
            _ent.movies.Remove(deletedMovie);
            _ent.SaveChanges();

            return GetAllMovies();
        }

        public class MovieRec
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string videoUrl { get; set; }
            public int categoryId { get; set; }
            public Nullable<System.DateTime> date { get; set; }
            public string categoryName { get; set; }
            public string lang_suntitle { get; set; }
            public Nullable<int> year { get; set; }
            public Nullable<int> imdb { get; set; }
        }

        public List<CategoryRec> GetAllCategories()
        {
            return _ent.categories.Select(p => new CategoryRec()
            {
                id = p.id,
                name = p.name
            }).ToList();
        }

        public CategoryRec GetCategory(int CategoryID)
        {
            return _ent.categories.Where(p => p.id == CategoryID).Select(p => new CategoryRec()
            {
                id = p.id,
                name = p.name
            }).FirstOrDefault();
        }

        public List<CategoryRec> DeleteCategory(int CategoryID)
        {
            movies deletedCategory = _ent.movies.Find(CategoryID);
            _ent.movies.Remove(deletedCategory);
            _ent.SaveChanges();

            return GetAllCategories();
        }

        public class CategoryRec
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public UsersRec userControl(string email, string pass)
        {
            return _ent.users.Where(p => p.email == email && p.pass == pass).Select(p => new UsersRec()
            {
                id = p.id,
                email = p.email,
                pass = p.pass                
            }).FirstOrDefault();
        }

        public class UsersRec
        {
            public int id { get; set; }
            public string email { get; set; }
            public string pass { get; set; }
        }
    }
}
