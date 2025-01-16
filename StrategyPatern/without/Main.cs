using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatern.without;

        public class PaymentProcessor
        {
            public void ProcessPayment(decimal amount, string method)
            {
                if (method == "CreditCard")
                {
                    // Logic to process credit card payment
                    Console.WriteLine($"Processing {amount} via Credit Card");
                }
            }
        }
    public class Main
    {

        public Main()
        {
        // Usage
        var paymentProcessor = new PaymentProcessor();
        paymentProcessor.ProcessPayment(100.00m, "CreditCard");



        // Usage
        var paymentProcessor1 = new PaymentProcessor1();
        paymentProcessor1.ProcessPayment(100.00m, "CreditCard");
        paymentProcessor1.ProcessPayment(75.50m, "PayPal");
    }
  

    }
    public class PaymentProcessor1
    {
        public void ProcessPayment(decimal amount, string method)
        {
            if (method == "CreditCard")
            {
                // Logic to process credit card payment
                Console.WriteLine($"Processing {amount} via Credit Card");
            }
            else if (method == "PayPal")
            {
                // Logic to process PayPal payment
                Console.WriteLine($"Processing {amount} via PayPal");
            }
            // As new payment methods are added, more if-else statements are added here
        }
    }



