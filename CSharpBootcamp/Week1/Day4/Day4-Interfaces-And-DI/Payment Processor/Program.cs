namespace Payment_Processor
{
    internal class Program
    {
        public interface IPaymentProcessor
        {
            void ProcessPayment(decimal amount);
        }

        public class PaypalProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
        => Console.WriteLine($"Processed {amount:C} via PayPal");
        }

        public class StripeProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount) => Console.WriteLine($"Processed {amount:C} via Stripe");
        }

        public interface IOrderService
        {
            void PlaceOrder(decimal amount);
        }

        public class OrderService
        {
            public readonly IPaymentProcessor _processor;

            public OrderService(IPaymentProcessor processor)
            {
                _processor = processor;
            }

            public void PlaceOrder(decimal amount)
            {
                _processor.ProcessPayment(amount);
                Console.WriteLine("Order placed successfully!");
            }
        }

        public static void Main(string[] args)
        {
            var orderService = new OrderService(new StripeProcessor());
            orderService.PlaceOrder(499.99m);
        }
    }
}
