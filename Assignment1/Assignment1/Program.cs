using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("1. Printing Even Numbers");
        Console.WriteLine("\n2. Printing Dividers or Equals by M");
        Console.WriteLine("\n3. Printing Words from End to Start");
        Console.WriteLine("\n4. Printing the Number of Words and Letters in a Sentence");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                PrintEvenNumbers();
                break;
                
            case 2: 
                PrintNumbersDivisibleByM();
                break;

            case 3:
                ReversePrintWords();
                break;

            case 4:
                PrintWordAndCharacterCount();
                break;
        }
    }

    static void PrintEvenNumbers()
    {
        Console.Write("Enter a positive number (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Please enter {n} positive numbers:");

        for (int i = 0; i < n; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
                Console.WriteLine(num);
        }
    }

    static void PrintNumbersDivisibleByM()
    {
        Console.Write("Enter a positive number (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter a positive number (n): ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Please enter {n} positive numbers:");

        for (int i = 0; i < n; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % m == 0)
                Console.WriteLine(num);
        }
    }

    static void ReversePrintWords()
    {
        Console.Write("Enter a positive number (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Please enter {n} words:");

        string[] words = new string[n];

        for (int i = 0; i < n; i++)
        {
            words[i] = Console.ReadLine();
        }

        Console.WriteLine("Reverse order of entered words:");

        for (int i = n - 1; i >= 0; i--)
        {
            Console.WriteLine(words[i]);
        }
    }

    static void PrintWordAndCharacterCount()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        string[] words = sentence.Split(' ');

        int wordCount = words.Length;
        int numberOfLetters = sentence.Length;

        Console.WriteLine($"Total word count: {wordCount}");
        Console.WriteLine($"Total number of letters: {numberOfLetters}");
    }
}
