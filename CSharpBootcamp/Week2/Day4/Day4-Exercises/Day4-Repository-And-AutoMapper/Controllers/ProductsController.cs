using AutoMapper;
using Day4_Repository_And_AutoMapper.Models;
using Day4_Repository_And_AutoMapper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Day4_Repository_And_AutoMapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repo.AddAsync(product);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, _mapper.Map<ProductDto>(product));
        }
    }
}
