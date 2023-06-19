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
            return Ok($"{this.Name}, {this.Country}"); // when making request, you have to send this data from body form data section
        }
        [HttpPost("")]
        public IActionResult GetAnimal(AnimalModel animal)
        {
            return Ok($"{animal.Name}, {animal.Id}"); // when making request, you have to send this data from body raw section
        }

        [HttpPost("")]
        public IActionResult AddAnimal([FromQuery]AnimalModel animal, int type, [FromQuery]int anotherVarialbe) // FromQuery force to take the data from query string and not from other parts.
        {
            return Ok($"{animal.Name}, {animal.Id}"); 
        }

        [HttpPost("id/name")]
        public IActionResult CheckAnimal([FromRoute] AnimalModel animal) // FromRoute force to take the data from route(abc.com/id/name) and not from other parts.
        {
            return Ok($"{animal.Name}, {animal.Id}");
        }

        // FromBody -> to take data from body
        // FromForm -> to take data from form data
        // FromHeader -> to take data from header
    }
}
