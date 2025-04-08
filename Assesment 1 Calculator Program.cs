using System;

public class SimpleCalculator
{

    private static string[] history = new string[10];
    private static int historyCount = 0;

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            DisplayMainMenu();

            Console.Write("Enter your choice (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformCalculation("+");
                    break;
                case "2":
                    PerformCalculation("-");
                    break;
                case "3":
                    PerformCalculation("*");
                    break;
                case "4":
                    PerformCalculation("/");
                    break;
                case "5":
                    PerformCalculation("%");
                    break;
                case "6":
                    ShowHistory();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("===WELCOME TO THE CALCULATOR ===");
        Console.WriteLine("1. Addition (+)");
        Console.WriteLine("2. Subtraction (-)");
        Console.WriteLine("3. Multiplication (*)");
        Console.WriteLine("4. Division (/)");
        Console.WriteLine("5. Modulus (%)");
        Console.WriteLine("6. View History");
        Console.WriteLine("7. Exit");
        Console.WriteLine("\nTIP: Enter the number corresponding to the operation you want to perform.");
    }

    private static void PerformCalculation(string operation)
    {
        Console.Clear();
        Console.WriteLine($"=== {GetOperationName(operation)} ===");

       
        double num1 = GetNumber("Enter first number: ");
        double num2 = GetNumber("Enter second number: ");

        
        double result = 0;
        string operationSymbol = operation;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Cannot divide by zero!");
                    AddToHistory($"{num1} {operation} {num2} = Error (division by zero)");
                    return;
                }
                result = num1 / num2;
                break;
            case "%":
                result = num1 % num2;
                break;
        }

       
        Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
        AddToHistory($"{num1} {operation} {num2} = {result}");
    }

    private static double GetNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double number))
            {
                return number;
            }

            Console.WriteLine("Invalid number. Please try again.");
        }
    }

    private static string GetOperationName(string operation)
    {
        switch (operation)
        {
            case "+": return "ADDITION";
            case "-": return "SUBTRACTION";
            case "*": return "MULTIPLICATION";
            case "/": return "DIVISION";
            case "%": return "MODULUS";
            default: return "CALCULATION";
        }
    }

    private static void AddToHistory(string entry)
    {
        if (historyCount < history.Length)
        {
            history[historyCount] = entry;
            historyCount++;
        }
        else
        {
       
            for (int i = 0; i < history.Length - 1; i++)
            {
                history[i] = history[i + 1];
            }
            history[history.Length - 1] = entry;
        }
    }

    private static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("=== CALCULATION HISTORY ===");

        if (historyCount == 0)
        {
            Console.WriteLine("No history available.");
            return;
        }

        for (int i = 0; i < historyCount; i++)
        {
            Console.WriteLine(history[i]);
        }

        Console.WriteLine("TIP: History shows your last 10 calculations.");
    }
}