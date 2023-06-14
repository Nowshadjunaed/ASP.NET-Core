using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController
    {
        [Route("{id:int:min(3):max(10)}")] // it will accept id if it is int and min val = 3 and max val = 10
        public string Get(int id)
        {
            return $"get int {id}";
        }

        [Route("{id:length(5)}")] // the default type is string and the length of the string must be 5. there are function for minlength(), maxlength(), range(2,5)
                                  // can include :alpha which means only alphabetic characters are allowed. 
                                  // can include :required to make variable required
        public string GetString(string id)
        {
            return $"get string {id}";
        }
        [Route("{id:regex(a(b|c))}")]
        public string GetRegex(string id)
        {
            return $"get regex {id}";
        }
    }
}
