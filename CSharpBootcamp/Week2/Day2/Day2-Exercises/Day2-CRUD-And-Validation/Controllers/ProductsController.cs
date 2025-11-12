using Day2_CRUD_And_Validation.Models;
using Day2_CRUD_And_Validation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day2_CRUD_And_Validation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
            => _service.GetById(id) is { } p ? Ok(p) : NotFound();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest("ID mismatch");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _service.Update(product) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => _service.Delete(id) ? NoContent() : NotFound();
    }
}
