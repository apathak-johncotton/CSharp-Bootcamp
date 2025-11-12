using Week2Day1_FirstWebAPI.Models;

namespace Week2Day1_FirstWebAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
    }
}
