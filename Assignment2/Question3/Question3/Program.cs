using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine().ToLower();

        char[] vowels = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };

        char[] vowelSequence = sentence.Where(c => vowels.Contains(c)).ToArray();
        Array.Sort(vowelSequence);

        Console.WriteLine($"Vowels: {string.Join(", ", vowelSequence)}");
    }
}

