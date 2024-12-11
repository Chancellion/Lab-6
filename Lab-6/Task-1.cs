using System;
public class Calculator<T> where T : struct
{
    public delegate T Operation(T a, T b);
    public T Add(T a, T b, Operation addOperation)
    {
        return addOperation(a, b);
    }

    public T Subtract(T a, T b, Operation subtractOperation)
    {
        return subtractOperation(a, b);
    }
    public T Multiply(T a, T b, Operation multiplyOperation)
    {
        return multiplyOperation(a, b);
    }
    public T Divide(T a, T b, Operation divideOperation)
    {
        return divideOperation(a, b);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Данiїл Iванченко, КIб-1-23-4.0д");
        Calculator<int> intCalculator = new Calculator<int>();
        Calculator<double> doubleCalculator = new Calculator<double>();
        Calculator<int>.Operation intAdd = (a, b) => a + b;
        Calculator<int>.Operation intSubtract = (a, b) => a - b;
        Calculator<int>.Operation intMultiply = (a, b) => a * b;
        Calculator<int>.Operation intDivide = (a, b) => a / b;
        int intResultAdd = intCalculator.Add(10, 5, intAdd);
        int intResultSubtract = intCalculator.Subtract(10, 5, intSubtract);
        int intResultMultiply = intCalculator.Multiply(10, 5, intMultiply);
        int intResultDivide = intCalculator.Divide(10, 5, intDivide);
                Console.WriteLine("Данiїл Iванченко, КIб-1-23-4.0д");
        Console.WriteLine($"INT Додавання: {intResultAdd}");
        Console.WriteLine($"INT Вiднiмання: {intResultSubtract}");
        Console.WriteLine($"INT Множення: {intResultMultiply}");
        Console.WriteLine($"INT Дiлення: {intResultDivide}");
        Calculator<double>.Operation doubleAdd = (a, b) => a + b;
        Calculator<double>.Operation doubleSubtract = (a, b) => a - b;
        Calculator<double>.Operation doubleMultiply = (a, b) => a * b;
        Calculator<double>.Operation doubleDivide = (a, b) => a / b;
        double doubleResultAdd = doubleCalculator.Add(10.5, 5.2, doubleAdd);
        double doubleResultSubtract = doubleCalculator.Subtract(10.5, 5.2, doubleSubtract);
        double doubleResultMultiply = doubleCalculator.Multiply(10.5, 5.2, doubleMultiply);
        double doubleResultDivide = doubleCalculator.Divide(10.5, 5.2, doubleDivide);
        Console.WriteLine($"DOUBLE Додавання: {doubleResultAdd}");
        Console.WriteLine($"DOUBLE Вiднiмання: {doubleResultSubtract}");
        Console.WriteLine($"DOUBLE Множення: {doubleResultMultiply}");
        Console.WriteLine($"DOUBLE Дiлення: {doubleResultDivide}");
    }
}
