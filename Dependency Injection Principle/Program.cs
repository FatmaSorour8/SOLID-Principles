namespace Dependency_Injection_Principle
{
    // Interfaces for PaymentProcessor and NotificationService
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public interface INotificationService
    {
        void SendNotification(string message);
    }

    // Concrete implementations of PaymentProcessor and NotificationService
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            // Code to send email
            Console.WriteLine(message);
        }
    }

    // Product management class
    public class ProductManager
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
    }

    // Order processing class
    public class OrderProcessor
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly INotificationService _notificationService;

        public OrderProcessor(IPaymentProcessor paymentProcessor, INotificationService notificationService)
        {
            _paymentProcessor = paymentProcessor;
            _notificationService = notificationService;
        }

        public Order PlaceOrder(string customerName, List<Product> products)
        {
            decimal totalCost = products.Sum(p => p.Price);
            _paymentProcessor.ProcessPayment(totalCost);

            Order order = new Order { CustomerName = customerName, Products = products, TotalCost = totalCost };
            _notificationService.SendNotification(GetOrderConfirmationMessage(order));

            return order;
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

    // Main class
    public class ECommerceSystem
    {
        private readonly ProductManager _productManager;
        private readonly OrderProcessor _orderProcessor;

        public ECommerceSystem(ProductManager productManager, OrderProcessor orderProcessor)
        {
            _productManager = productManager;
            _orderProcessor = orderProcessor;
        }

        public void AddProduct(string name, decimal price, int quantity)
        {
            _productManager.AddProduct(name, price, quantity);
        }

        public Order PlaceOrder(string customerName, List<int> productIds, string paymentMethod)
        {
            List<Product> products = new List<Product>();
            foreach (int productId in productIds)
            {
                Product product = _productManager.GetProductById(productId);
                if (product != null && product.Quantity > 0)
                {
                    products.Add(product);
                    product.Quantity--;
                }
            }

            IPaymentProcessor paymentProcessor;
            switch (paymentMethod)
            {
                case "CreditCard":
                    paymentProcessor = new CreditCardPaymentProcessor();
                    break;
                case "PayPal":
                    paymentProcessor = new PayPalPaymentProcessor();
                    break;
                default:
                    throw new ArgumentException("Invalid payment method");
            }

            return _orderProcessor.PlaceOrder(customerName, products);
        }
    }

    // Remaining classes (Product and Order) remain unchanged
}
