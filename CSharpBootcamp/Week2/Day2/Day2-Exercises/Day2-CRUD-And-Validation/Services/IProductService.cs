using Day2_CRUD_And_Validation.Models;

namespace Day2_CRUD_And_Validation.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
