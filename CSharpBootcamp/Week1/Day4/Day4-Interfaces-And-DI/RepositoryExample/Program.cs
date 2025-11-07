namespace RepositoryExample
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
    }

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        public void Add(Product p) => _products.Add(p);

        public IEnumerable<Product> GetAll() => _products;
    }

    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product p)
        {
            _repository.Add(p);
        }

        public void ListProducts()
        {
            foreach (var p in _repository.GetAll())
                Console.WriteLine($"{p.Name} - {p.Price:C}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService(new InMemoryProductRepository());
            productService.AddProduct(new Product { Name = "toy", Price = 10.00m });
            productService.ListProducts();
        }
    }
}
