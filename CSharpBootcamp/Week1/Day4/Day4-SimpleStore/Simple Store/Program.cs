using Simple_Store;

namespace Simple_Store
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetById(int id);

    }

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        public void Add(Product p) => _products.Add(p);

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }

    public interface IPaymentProcessor
    {
        string Name { get; }
        bool ProcessPayment(decimal amount);
    }

    public class CardPaymentProcessor : IPaymentProcessor
    {
        public string Name { get { return "Card"; } }

        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine("[Card] Processing payment of " + amount.ToString("C"));
            // Simulate success
            return true;
        }
    }

    public class PaypalPaymentProcessor : IPaymentProcessor
    {
        public string Name { get { return "PayPal"; } }

        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine("[PayPal] Processing payment of " + amount.ToString("C"));
            // Simulate success
            return true;
        }
    }


    public interface IOrderService
    {
        bool PlaceOrder(int productId, int quantity, IPaymentProcessor paymentProcessor);
    }

    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool PlaceOrder(int productId, int quantity, IPaymentProcessor paymentProcessor)
        {
            if (paymentProcessor == null)
            {
                Console.WriteLine("No payment processor selected.");
                return false;
            }

            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return false;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be at least 1.");
                return false;
            }

            var total = product.Price * quantity;
            Console.WriteLine("Placing order: " + quantity + " x " + product.Name + " @ " +
                              product.Price.ToString("C") + " = " + total.ToString("C"));

            var success = paymentProcessor.ProcessPayment(total);

            if (success)
            {
                Console.WriteLine("Order successful! ✅");
            }
            else
            {
                Console.WriteLine("Payment failed. Order cancelled. ❌");
            }

            return success;
        }
    }

    public class StoreApp
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderService _orderService;
        private readonly List<IPaymentProcessor> _paymentProcessors;

        public StoreApp(IProductRepository productRepository,
                        IOrderService orderService,
                        List<IPaymentProcessor> paymentProcessors)
        {
            _productRepository = productRepository;
            _orderService = orderService;
            _paymentProcessors = paymentProcessors;
        }

        public void Run()
        {
            SeedSampleProducts();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== SIMPLE STORE =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Buy Product");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddProductFlow();
                        break;
                    case "2":
                        ListProductsFlow();
                        break;
                    case "3":
                        BuyProductFlow();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void SeedSampleProducts()
        {
            if (!_productRepository.GetAll().Any())
            {
                _productRepository.Add(new Product { Name = "Keyboard", Price = 25.99M });
                _productRepository.Add(new Product { Name = "Mouse", Price = 15.50M });
                _productRepository.Add(new Product { Name = "Monitor", Price = 199.99M });
            }
        }

        private void AddProductFlow()
        {
            Console.Write("Enter product name: ");
            var name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            _productRepository.Add(new Product
            {
                Name = name,
                Price = price
            });

            Console.WriteLine("Product added successfully.");
        }

        private void ListProductsFlow()
        {
            var products = _productRepository.GetAll().ToList();

            if (!products.Any())
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine("Available Products:");
            foreach (var p in products)
            {
                Console.WriteLine(p.Id + ". " + p.Name + " - " + p.Price.ToString("C"));
            }
        }

        private void BuyProductFlow()
        {
            ListProductsFlow();
            Console.WriteLine();

            Console.Write("Enter Product Id to buy: ");
            int productId;
            if (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.WriteLine("Invalid Product Id.");
                return;
            }

            Console.Write("Enter quantity: ");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Choose Payment Method:");
            for (int i = 0; i < _paymentProcessors.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + _paymentProcessors[i].Name);
            }
            Console.Write("Select: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) ||
                choice < 1 ||
                choice > _paymentProcessors.Count)
            {
                Console.WriteLine("Invalid payment choice.");
                return;
            }

            var selectedProcessor = _paymentProcessors[choice - 1];
            _orderService.PlaceOrder(productId, quantity, selectedProcessor);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new InMemoryProductRepository();
            IOrderService orderService = new OrderService(productRepository);

            var paymentProcessors = new List<IPaymentProcessor>
            {
                new CardPaymentProcessor(),
                new PaypalPaymentProcessor()
            };

            var app = new StoreApp(productRepository, orderService, paymentProcessors);
            app.Run();
        }
    }
}
