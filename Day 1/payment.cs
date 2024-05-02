    public enum PaymentType
        {
            CreditCard,
            PayPal,
            BankTransfer
        }

    // Define an interface to represent the behavior of payment methods
    public interface IPaymentProcessor
        {
            void ProcessPayment(double amount);
        }

    // Implement classes for each payment method, all implementing the IPaymentProcessor interface
    internal class CreditCardPayment : IPaymentProcessor
        {
            public void ProcessPayment(double amount)
            {
                
            }
        }

    internal class PayPalPayment : IPaymentProcessor
        {
            public void ProcessPayment(double amount)
            {
                
            }
        }

    internal class BankTransferPayment : IPaymentProcessor
        {
            public void ProcessPayment(double amount)
            {
                
            }
        }

    internal class PaymentProcess
        {
            public void ProcessPayment(IPaymentProcessor paymentProcessor, double amount)
            {
                
                paymentProcessor.ProcessPayment(amount);
            }
        }