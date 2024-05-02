public interface IOrderProcessor
    {
        void ProcessOrder(string customerName, List<int> productIds, string paymentMethod);
    }

    public class OrderProcessor : IOrderProcessor
    {
        private readonly IProductRepository _productRepository;
        private readonly IPaymentProcessor2Factory _paymentProcessorFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;

        public OrderProcessor(IProductRepository productRepository, IPaymentProcessor2Factory paymentProcessorFactory, IOrderRepository orderRepository, IEmailService emailService)
        {
            _productRepository = productRepository;
            _paymentProcessorFactory = paymentProcessorFactory;
            _orderRepository = orderRepository;
            _emailService = emailService;
        }

        public void ProcessOrder(string customerName, List<int> productIds, string paymentMethod)
        {
            List<Product> orderedProducts = new List<Product>();
            decimal totalCost = 0;

            foreach (int productId in productIds)
            {
                Product product = _productRepository.GetProductById(productId);

                if (product != null && product.Quantity > 0)
                {
                    orderedProducts.Add(product);
                    totalCost += product.Price;
                    product.Quantity--;
                }
            }

            if (orderedProducts.Count > 0)
            {
                IPaymentProcessor2 paymentProcessor = _paymentProcessorFactory.CreatePaymentProcessor(paymentMethod);
                paymentProcessor.ProcessPayment(totalCost);

                Order order = new Order
                {
                    CustomerName = customerName,
                    Products = orderedProducts,
                    TotalCost = totalCost
                };

                _orderRepository.AddOrder(order);
                _emailService.SendOrderConfirmationEmail(order);
            }
        }
    }

    public interface IPaymentProcessor2
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardPaymentProcessor : IPaymentProcessor2
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }
    }

    public class PayPalPaymentProcessor : IPaymentProcessor2
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
    }

    public interface IPaymentProcessor2Factory
    {
        IPaymentProcessor2 CreatePaymentProcessor(string paymentMethod);
    }

    public class PaymentProcessorFactory : IPaymentProcessor2Factory
    {
        public IPaymentProcessor2 CreatePaymentProcessor(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "CreditCard":
                    return new CreditCardPaymentProcessor();
                case "PayPal":
                    return new PayPalPaymentProcessor();
                default:
                    throw new NotSupportedException($"Payment method {paymentMethod} is not supported");
            }
        }
    }

    public interface IProductRepository
    {
        Product GetProductById(int productId);
    }

    public interface IOrderRepository
    {
        void AddOrder(Order order);
    }

    public interface IEmailService
    {
        void SendOrderConfirmationEmail(Order order);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalCost { get; set; }
    }