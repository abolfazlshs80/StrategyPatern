using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatern.without;

    internal class second
    {
        public second()
        {
        Calculator calculator = new();
        Console.WriteLine("Addition: " + calculator.ExecuteOperation("Addition", 10, 5)); // Output: 15
        Console.WriteLine("Subtraction: " + calculator.ExecuteOperation("Subtraction", 10, 5)); // Output: 5
        Console.WriteLine("Multiplication: " + calculator.ExecuteOperation("Multiplication", 10, 5)); // Output: 50
        Console.WriteLine("Division: " + calculator.ExecuteOperation("Division", 10, 5)); // Output: 2

    }
}

public class Calculator
{
    public int ExecuteOperation(string operation, int a, int b)
    {
        switch (operation)
        {
            case "Addition":
                return a + b;
            case "Subtraction":
                return a - b;
            case "Multiplication":
                return a * b;
            case "Division":
                return a / b;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
}


