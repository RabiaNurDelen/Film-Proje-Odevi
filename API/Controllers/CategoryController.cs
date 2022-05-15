using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class CategoryController : ApiController
    {
        DatabaseOperations.MoviesOperations co = new DatabaseOperations.MoviesOperations();

        [HttpGet]
        public List<DatabaseOperations.MoviesOperations.CategoryRec> GetAllCategories()
        {
            return co.GetAllCategories();
        }

        [HttpGet]
        public DatabaseOperations.MoviesOperations.CategoryRec GetCategory(int CategoryID)
        {
            return co.GetCategory(CategoryID);
        }

        [HttpGet]
        public List<DatabaseOperations.MoviesOperations.CategoryRec> DeleteCategory(int CategoryID)
        {
            return co.DeleteCategory(CategoryID);
        }

    }
}