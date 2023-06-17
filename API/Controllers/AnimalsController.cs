using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<AnimalModel> animals = null;
        public AnimalsController()
        {
            animals = new List<AnimalModel>()
            {
                new AnimalModel() { Id = 1, Name = "Dog" },
                new AnimalModel() { Id = 2, Name = "Lion" }
            };
        }
        [Route("ok",Name = "all")]
        public IActionResult GetAnimals()
        {
            return Ok(animals);
        }
        [Route("accepted")]
        public IActionResult GetAnimalsList()
        {
            //return Accepted("~/api/animals");
            //return AcceptedAtAction("GetAnimals");
            return AcceptedAtRoute("all");
        }

        [Route("{name}")]
        public IActionResult GetAnimalsByName(string name)
        {
            if (!name.Contains("ABC"))
            {
                return BadRequest();
            }

            return Ok(animals);
        }


        [Route("{id:int}")]
        public IActionResult GetAnimalsById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var animal = animals.FirstOrDefault(x => x.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpPost("")]
        public IActionResult GetAnimals(AnimalModel animal)
        {
            animals.Add(animal);

            //return CreatedAtAction("~/api/animals/"+animal.Id, animal);
            return CreatedAtAction("GetAnimalsById", new { id = animal.Id }, animal);
        }

        [Route("redirect")]
        public IActionResult GetAnimalsTest()
        {
            //return LocalRedirect("~/api/animals/ok");
            return LocalRedirectPermanent("~/api/animals/ok");
        }

    }
}
