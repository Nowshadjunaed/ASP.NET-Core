using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/test/[action]")]
    public class TestController : ControllerBase
    {
        public string get()
        {
            return "that's nice";
        }
        public string get1()
        {
            return "that's awesome";
        }
    }
}
