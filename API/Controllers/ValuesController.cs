using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // I included it here, so all the route inside the class will inherit this. Like to access the
                                     // get-all method, I have to hit on localhost:7273/Values/GetAll/get-all
    public class ValuesController : ControllerBase
    {
        [Route("get-all")]
        public string GetAll()
        {
            return "get all";
        }
        [Route("~/get-all-authors")] // for the ~/, this method won't inherit Route("[controller]/[action]") that is declared under [ApiController] attribute.
        public string GetAllAuthors()
        {
            return "get all authors";
        }
        [Route("books/{id}")]
        public string GetBookById(int id)
        {
            return $"Book Id: {id}";
        }
        [Route("books/{id}/author/{authorId}")]
        public string GetAuthorDetailsById(int id, int authorId)
        {
            return $"Author Details: {id} and {authorId}";
        }
        [Route("search")]
        public string SearchBook(int id, int tk, string name, string random) // Query string
        {
            return $"I am From search book.";
        }

        [Route("url1")]
        [Route("url2")]
        [Route("url3")]
        public string SingleResourceByMultipleURLs()
        {
            return "You can access me through multiple urls";
        }

        //[Route("[controller]/[action]")] // [controller] will be replaced by controller name. In this case, the name is Values. action is replaced by method name
        public string ControllerMethod()
        {
            return "I am from controller method";
        }



    }
}
