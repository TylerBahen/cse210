using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select an activity:\n1. Breathing Activity");
            string selection = Console.ReadLine();
            if (selection="1")
            {
                Console.WriteLine("How long would you like to breathe for? (This activity guides you in 8 second cycles)");
                string durationRaw = Console.ReadLine();
            }
        }
    }
}