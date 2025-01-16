using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatern.with;

    public class Second
    {
        public Second()
        {
        Calculator calculator = new();
        calculator.SetStrategy(new AdditionStrategy());
        Console.WriteLine("Addition: " + calculator.ExecuteOperation(10, 5)); // Output: 15

        calculator.SetStrategy(new SubtractionStrategy());
        Console.WriteLine("Subtraction: " + calculator.ExecuteOperation(10, 5)); // Output: 5

        calculator.SetStrategy(new MultiplicationStrategy());
        Console.WriteLine("Multiplication: " + calculator.ExecuteOperation(10, 5)); // Output: 50

        calculator.SetStrategy(new DivisionStrategy());
        Console.WriteLine("Division: " + calculator.ExecuteOperation(10, 5)); // Output: 2

    }
}

    public interface IOperationStrategy
    {
        int Execute(int a, int b);
    }
public class AdditionStrategy : IOperationStrategy
{
    public int Execute(int a, int b) => a + b;
}

public class SubtractionStrategy : IOperationStrategy
{
    public int Execute(int a, int b) => a - b;
}

public class MultiplicationStrategy : IOperationStrategy
{
    public int Execute(int a, int b) => a * b;
}

public class DivisionStrategy : IOperationStrategy
{
    public int Execute(int a, int b) => a / b;
}


public class Calculator
{
    private IOperationStrategy _strategy;

    public void SetStrategy(IOperationStrategy strategy)
    {
        _strategy = strategy;
    }

    public int ExecuteOperation(int a, int b)
    {
        return _strategy.Execute(a, b);
    }
}
