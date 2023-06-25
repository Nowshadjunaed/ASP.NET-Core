using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("single")]
        public EmployeeModel GetEmployee()
        {
            return new EmployeeModel() { Id = 1 , Name = "Nowshad"};
        }
        [Route("all")]
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return new List<EmployeeModel>() {
                new EmployeeModel() { Id = 1 , Name = "Nowshad"},
                new EmployeeModel() { Id = 2 , Name = "Junaed"}
            };
        
        }

        [Route("{id}")]
        public IActionResult GetEmployeeById(int id) // we use IActionResult as return type to return multiple types of data
        {
            if (id == 0) {
                return NotFound();
            }
            return Ok(new List<EmployeeModel>() {
                new EmployeeModel() { Id = 1 , Name = "Nowshad"},
                new EmployeeModel() { Id = 2 , Name = "Junaed"}
            });

        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeeBasicDetails(int id) // here return type is EmployeeModel along with all return type supported by IActionResult 
        {
            if (id == 0) {
                return NotFound();
            }
            return new EmployeeModel() { Id = 1, Name = "Nowshad" };

        }

        [HttpPost("")]
        public IActionResult AddProduct([FromServices] IProductRepository _productRepository, [FromBody] ProductModel product) // resolving dependency in a particlular method. we can take the productRepository in constructor. But if we don't want other method to access that service and only a particular method can use this service, we can use [FromServices]
        {
            _productRepository.AddProduct(product);
            var products = _productRepository.GetProducts();
            return Ok(products);
        }
    }
}
