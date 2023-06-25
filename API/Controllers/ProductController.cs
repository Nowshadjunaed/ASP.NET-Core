using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) // if we use singleton and add another parameter of IProducRepository. let's say the param is productRepository2.
                                                                       // Then productRepository2 will be same as productRepository as we are using singleton. Same for the scoped also.
                                                                       // In scoped insided same http req, the instance will be shared but for different http req it'll create another instance.
                                                                       // But in transient, the instance never be shared. for same and different http request it'll create another instance.
        {
            //_productRepository = new ProductRepository(); // this is a bad idea and this controller is tightly coupled with productRepository
                                                          // Every time we hit at the route, a new instance of ProductRepository will be created which is not a good idea.
                                                          // Another problem is, everytime we add product it will add to the new instance so the id of the product will be 1 every time 
            
            _productRepository = productRepository; // using singleton for dependency injection
        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            _productRepository.AddProduct(product);
            var products = _productRepository.GetProducts();
            return Ok(products);
        }
    }
}
