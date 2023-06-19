using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [BindProperties] -> this same as BindProperty, but it works on controller level and applicable to all the property of the controller.
    public class ModelBinder : ControllerBase
    {
        [BindProperty] // [BindProperty(SupportsGet = true)] for supporting get req
        public string Name { get; set; }
        [BindProperty]
        public string Country { get; set; }
        [HttpPost("")]
        public IActionResult AddCountry()
        {
            return Ok($"{this.Name}, {this.Country}"); // when making request, you have to send this data from form data
        }
        [HttpPost("")]
        public IActionResult GetAnimal(AnimalModel animal)
        {
            return Ok($"{animal.Name}, {animal.Id}"); // when making request, you have to send this data from body raw section
        }

        [HttpPost("")]
        public IActionResult AddAnimal([FromQuery]AnimalModel animal, int type) // FromQuery force to take the data from query string and not from other part.
        {
            return Ok($"{animal.Name}, {animal.Id}"); 
        }
    }
}
