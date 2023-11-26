using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[20];

        for (int i = 0; i < 20; i++)
        {
            Console.Write($"{i + 1}. enter number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine("Invalid enter. Please enter a number.");
                i--;
            }
        }

        Array.Sort(numbers);

        int[] smallestThreeNumber = new int[] { numbers[0], numbers[1], numbers[2] };
        int[] biggerThreeNumber = new int[] { numbers[17], numbers[18], numbers[19] };

        double smallestAverage = Average(smallestThreeNumber);
        double biggestAverage = Average(biggerThreeNumber);

        Console.WriteLine($"Samllest 3 Number: {string.Join(", ", smallestThreeNumber)}");
        Console.WriteLine($"Bigger 3 Number: {string.Join(", ", biggerThreeNumber)}");
        Console.WriteLine($"Smallest 3 Number Average: {smallestAverage}");
        Console.WriteLine($"Bigger 3 Number Average: {biggestAverage}");
        Console.WriteLine($"Total Average: {(smallestAverage + biggestAverage) / 2}");
    }

    static double Average(int[] arr)
    {
        if (arr.Length == 0) return 0;

        double result = 0;
        foreach (int num in arr)
        {
            result += num;
        }

        return result / arr.Length;
    }
}

