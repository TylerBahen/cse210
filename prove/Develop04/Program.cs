using System;
using Activites;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select an activity:\n1. Breathing Activity\n2. Reflection\n3. Listing\n4. Quit");
            string selection = Console.ReadLine();
            if (selection == "1")
            {
                Breathing activity = new Breathing();
            }
            else if (selection == "2")
            {
                Reflection activity = new Reflection();
            }
            else if (selection == "3")
            {
                Listing activity = new Listing();
            }
            else if (selection == "4")
            {
                Console.WriteLine("Thank you, have a nice day :)");
                running = false;
            }
        }
    }
}