using Day2_CRUD_And_Validation.Models;
using System.Xml.Linq;

namespace Day2_CRUD_And_Validation.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new()
    {
        new() { Id = 1, Name = "Pillow", Price = 19.99m },
        new() { Id = 2, Name = "Duvet", Price = 59.99m }
    };

        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public void Add(Product product) => _products.Add(product);

        public bool Update(Product updated)
        {
            var existing = GetById(updated.Id);
            if (existing is null) return false;
            existing.Name = updated.Name;
            existing.Price = updated.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            return product is not null && _products.Remove(product);
        }
    }
}
