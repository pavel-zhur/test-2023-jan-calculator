using Test.Calculator.App;
using Test.Calculator.Operations;
using Test.Calculator.Operations.Base;

// see output.txt

Console.OutputEncoding = System.Text.Encoding.UTF8; // needed to be able to show unicode characters (double infinity) correctly

PrintMathAndSentence(
    "A normal expression example:",
    new Sum(2, new Faculty(new Multiplication(new Division(6, 2), 2))));

PrintMathAndSentence(
    "A subnormal result example:",
    new Sum(2, new Division(3, 0)));

PrintMathAndSentence(
    "An exception example:",
    new Faculty(new Multiplication(new Division(5, 2), 2)));

PrintMathAndSentence(
    "A known bug example:",
    new Subtraction(new Sum(5.6, 5.8), 0.4));

PrintMathAndSentence(
    "A custom operation example:",
    new Sum(3, new Logarithm(9, new Fraction(6, 2))));


void PrintMathAndSentence(string title, OperationBase operation)
{
    Console.WriteLine(title);
    PrintSafe(operation.Print);
    PrintSafe(operation.PrintSentence);
    Console.WriteLine();
}

void PrintSafe(Func<string> func)
{
    try
    {
        Console.WriteLine(func());
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.GetType().Name}: {e.Message}");
    }
}