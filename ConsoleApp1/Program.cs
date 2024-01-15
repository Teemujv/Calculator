using System;
using System.Collections.Generic;

class Calculator
{
    private int usageCount = 0;
    private List<string> calculationHistory = new List<string>();

    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.RunCalculator();
    }

    void RunCalculator()
    {
        while (true)
        {
            Console.WriteLine("Calculator Menu:");
            Console.WriteLine("1. Basic Calculation");
            Console.WriteLine("2. Square Root");
            Console.WriteLine("3. Power");
            Console.WriteLine("4. 10x");
            Console.WriteLine("5. Trigonometry Functions");
            Console.WriteLine("6. View Calculation History");
            Console.WriteLine("7. Clear Calculation History");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice (1-8): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BasicCalculation();
                    break;

                case "2":
                    SquareRoot();
                    break;

                case "3":
                    Power();
                    break;

                case "4":
                    TenX();
                    break;

                case "5":
                    TrigonometryFunctions();
                    break;

                case "6":
                    ViewCalculationHistory();
                    break;

                case "7":
                    ClearCalculationHistory();
                    break;

                case "8":
                    Exit();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                    break;
            }
        }
    }

    void BasicCalculation()
    {
        Console.Write("Enter expression: ");
        string expression = Console.ReadLine();

        try
        {
            double result = EvaluateExpression(expression);
            Console.WriteLine($"Result: {result}");
            AddToHistory(expression, result.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    void SquareRoot()
    {
        Console.Write("Enter a number: ");
        double number = Convert.ToDouble(Console.ReadLine());

        double result = Math.Sqrt(number);
        Console.WriteLine($"Square Root: {result}");
        AddToHistory($"sqrt({number})", result.ToString());
    }

    void Power()
    {
        Console.Write("Enter base: ");
        double baseNumber = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter exponent: ");
        double exponent = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(baseNumber, exponent);
        Console.WriteLine($"Result: {result}");
        AddToHistory($"{baseNumber}^{exponent}", result.ToString());
    }

    void TenX()
    {
        Console.Write("Enter exponent: ");
        double exponent = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(10, exponent);
        Console.WriteLine($"10^{exponent}: {result}");
        AddToHistory($"10^{exponent}", result.ToString());
    }

    void TrigonometryFunctions()
    {
        Console.WriteLine("Trigonometry Functions:");
        Console.WriteLine("1. Sine");
        Console.WriteLine("2. Cosine");
        Console.WriteLine("3. Tangent");

        Console.Write("Enter your choice (1-3): ");
        string choice = Console.ReadLine();

        Console.Write("Enter angle in degrees: ");
        double angle = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (choice)
        {
            case "1":
                result = Math.Sin(DegreeToRadian(angle));
                Console.WriteLine($"Sin({angle} degrees): {result}");
                AddToHistory($"sin({angle})", result.ToString());
                break;

            case "2":
                result = Math.Cos(DegreeToRadian(angle));
                Console.WriteLine($"Cos({angle} degrees): {result}");
                AddToHistory($"cos({angle})", result.ToString());
                break;

            case "3":
                result = Math.Tan(DegreeToRadian(angle));
                Console.WriteLine($"Tan({angle} degrees): {result}");
                AddToHistory($"tan({angle})", result.ToString());
                break;

            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                break;
        }
    }

    void ViewCalculationHistory()
    {
        Console.WriteLine("Calculation History:");
        for (int i = 0; i < calculationHistory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {calculationHistory[i]}");
        }
    }

    void ClearCalculationHistory()
    {
        calculationHistory.Clear();
        Console.WriteLine("Calculation history cleared.");
    }

    void Exit()
    {
        Console.WriteLine("Exiting calculator. Thank you!");
        Environment.Exit(0);
    }

    double EvaluateExpression(string expression)
    {
        return Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
    }

    void AddToHistory(string expression, string result)
    {
        calculationHistory.Add($"{expression} = {result}");
        usageCount++;
    }

    double DegreeToRadian(double degree)
    {
        return degree * (Math.PI / 180);
    }
}
