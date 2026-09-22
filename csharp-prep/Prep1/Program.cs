using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("First Name:");
        string first = Console.ReadLine();
        Console.WriteLine("Last Name:");
        string last = Console.ReadLine();
        Console.WriteLine($"Your name is {last}; {first} {last}.");
    }
}