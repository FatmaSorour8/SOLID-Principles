namespace SOLID_Exercise
{
    // Product Management
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(string name, decimal price, int quantity)
        {
            products.Add(new Product { Name = name, Price = price, Quantity = quantity });
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        // Additional methods for managing products
    }

    // Payment Processing
    public abstract class PaymentProcessor : IPaymentProcessor
    {
        public abstract void ProcessPayment(decimal amount);
    }

    public class CreditCardPaymentProcessor : PaymentProcessor
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }
    }

    public class PayPalPaymentProcessor : PaymentProcessor
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
    }

    // Notification Service
    public interface INotificationService
    {
        void SendNotification(string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            // Code to send email
            Console.WriteLine(message);
        }
    }

    // Order Management
    public class OrderService
    {
        private readonly ProductRepository _productRepository;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly INotificationService _notificationService;

        public OrderService(ProductRepository productRepository, IPaymentProcessor paymentProcessor, INotificationService notificationService)
        {
            _productRepository = productRepository;
            _paymentProcessor = paymentProcessor;
            _notificationService = notificationService;
        }

        public void PlaceOrder(string customerName, List<int> productIds, string paymentMethod)
        {
            List<Product> products = new List<Product>();
            foreach (int productId in productIds)
            {
                Product product = _productRepository.GetProductById(productId);
                if (product != null && product.Quantity > 0)
                {
                    products.Add(product);
                    product.Quantity--;
                }
            }

            decimal totalCost = products.Sum(p => p.Price);
            _paymentProcessor.ProcessPayment(totalCost);

            Order order = new Order { CustomerName = customerName, Products = products, TotalCost = totalCost };
            _notificationService.SendNotification(GetOrderConfirmationMessage(order));
        }

        private string GetOrderConfirmationMessage(Order order)
        {
            string message = $"Order confirmation for {order.CustomerName}:\n";
            message += $"Total Cost: ${order.TotalCost}\n";
            message += "Products:\n";
            foreach (Product product in order.Products)
            {
                message += $"- {product.Name} (${product.Price})\n";
            }
            return message;
        }
    }

    static void Main(string[] args)
    {
        var productRepository = new ProductRepository();
        var paymentProcessor = GetPaymentProcessor("PayPal"); 
        var notificationService = new EmailNotificationService();

        productRepository.AddProduct("White bag", 300.70m, 5);
        productRepository.AddProduct("Mostrizer", 450.55m, 3);

        var orderService = new OrderService(productRepository, paymentProcessor, notificationService);
        orderService.PlaceOrder("John Doe", new List<int> { 1, 2 }, "CreditCard");
    }

    static IPaymentProcessor GetPaymentProcessor(string paymentMethod)
    {
        return paymentMethod switch
        {
            "CreditCard" => new CreditCardPaymentProcessor(),
            "PayPal" => new PayPalPaymentProcessor(),
            _ => throw new ArgumentException("Invalid payment method"),
        };
    }
}
