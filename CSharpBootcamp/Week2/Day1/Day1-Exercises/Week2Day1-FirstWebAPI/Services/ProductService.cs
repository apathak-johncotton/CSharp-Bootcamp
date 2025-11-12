using Week2Day1_FirstWebAPI.Models;

namespace Week2Day1_FirstWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = [
            new(1, "Pillow", 19.99m),
        new(2, "Duvet", 59.99m),
        new(3, "Mattress", 299.99m)
        ];

        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
