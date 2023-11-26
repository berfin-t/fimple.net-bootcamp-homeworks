using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> primeList = new List<int>();
        List<int> nonPrimeList = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            Console.Write($"{i + 1}. enter positive number ");
            if (int.TryParse(Console.ReadLine(), out int enteredNumber) && enteredNumber > 0)
            {
                if (IsPrime(enteredNumber))
                {
                    primeList.Add(enteredNumber);
                }
                else
                {
                    nonPrimeList.Add(enteredNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid login. Please enter a positive number.");
                i--;
            }
        }

        primeList.Sort((a, b) => b.CompareTo(a));
        nonPrimeList.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine($"Prime numbers: {string.Join(", ", primeList)}");
        Console.WriteLine($"Non-Prime Numbers: {string.Join(", ", nonPrimeList)}");
        Console.WriteLine($"Prime Numbers Average: {Average(primeList)}");
        Console.WriteLine($"Non-Prime Numbers Average: {Average(nonPrimeList)}");
    }

    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    static double Average(List<int> list1)
    {
        if (list1.Count == 0) return 0;

        double sum = 0;
        foreach (int number in list1)
        {
            sum += number;
        }

        return sum / list1.Count;
    }
}

