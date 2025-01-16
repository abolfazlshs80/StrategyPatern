using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatern.with;

    public class Main
    {
        public Main()
        {
        var creditCardPayment = new PaymentProcessor(new CreditCardPaymentStrategy());
        creditCardPayment.ProcessPayment(100.00m);  // Output: Processing 100.00 via Credit Card

        var payPalPayment = new PaymentProcessor(new PayPalPaymentStrategy());
        payPalPayment.ProcessPayment(75.50m);  // Output: Processing 75.50 via PayPal


        //new used

        var cryptoPayment = new PaymentProcessor(new CryptoPaymentStrategy());
        cryptoPayment.ProcessPayment(50.00m);  // Output: Processing 50.00 via Cryptocurrency

    }
}

public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}


public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process Credit Card payment
        Console.WriteLine($"Processing {amount} via Credit Card");
    }
}

public class PayPalPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process PayPal payment
        Console.WriteLine($"Processing {amount} via PayPal");
    }
}



public class PaymentProcessor
{
    private IPaymentStrategy _paymentStrategy;

    public PaymentProcessor(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}


//add
public class CryptoPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing {amount} via Cryptocurrency");
        // Actual cryptocurrency processing logic
    }
}
