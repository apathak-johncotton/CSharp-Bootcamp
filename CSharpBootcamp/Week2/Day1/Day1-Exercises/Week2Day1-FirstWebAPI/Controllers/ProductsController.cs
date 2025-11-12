using Microsoft.AspNetCore.Mvc;
using Week2Day1_FirstWebAPI.Models;
using Week2Day1_FirstWebAPI.Services;

namespace Week2Day1_FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private static readonly List<Product> _products =
        [
            new(1, "Pillow", 19.99m),
            new(2, "Duvet", 59.99m),
            new(3, "Mattress", 299.99m)
        ];

        public ProductsController(IProductService service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Product?> GetById(int id)
        {
            var product = _service.GetById(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}
