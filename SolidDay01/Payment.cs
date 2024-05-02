using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDay01
{

    // Interface for payment method
    public interface IPaymentMethod
    {
        void ProcessPayment(double amount);
    }

    // Implemente CreditCardPayment class
    public class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment(double amount)
        {
            // code 
        }
    }

    // Implemente PayPalPayment class
    public class PayPalPayment : IPaymentMethod
    {
        public void ProcessPayment(double amount)
        {
            // code 
        }
    }

    // Implementw BankTransferPayment class
    public class BankTransferPayment : IPaymentMethod
    {
        public void ProcessPayment(double amount)
        {
            // code
        }
    }

    public class Payment
    {
        private IPaymentMethod _paymentMethod;

        public Payment(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void ProcessPayment(double amount)
        {
            _paymentMethod.ProcessPayment(amount);
        }
    }

}
