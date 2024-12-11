using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> items = new List<T>();
    public void Add(T item)
    {
        items.Add(item);
    }
    public delegate bool Criteria(T item);
    public List<T> Find(Criteria criteria)
    {
        List<T> result = new List<T>();
        foreach (T item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Данiїл Iванченко, КIб-1-23-4.0д");
        Repository<int> intRepository = new Repository<int>();
        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);
        intRepository.Add(5);
        Repository<int>.Criteria isEven = item => item % 2 == 0;
        List<int> evenNumbers = intRepository.Find(isEven);
        Console.WriteLine("Парні числа:");
        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
