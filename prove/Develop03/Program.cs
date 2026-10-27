using System;
using Scriptures;
using References;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        string again = "";
        do {
            again = "";
            Random random = new Random();
            string scriptureFile = File.ReadAllText("scriptures.csv");
            string[] scripturesRaw = scriptureFile.Split("\n");
            int selected = random.Next(0,scripturesRaw.Length);
            string[] scriptureRaw = scripturesRaw[selected].Split("~");
            Scripture scripture = new Scripture(scriptureRaw[0],new Reference(scriptureRaw[1],int.Parse(scriptureRaw[2]),int.Parse(scriptureRaw[3]),int.Parse(scriptureRaw[4])));
            scripture.Display();
            while (!scripture.IsTotallyHidden())
            {
                Console.ReadLine();
                scripture.HideRandomWord();
                scripture.Display();
            }
            Console.WriteLine("Play again? [Y/n]");
            while (again!="Y" && again!="N" && again != "n")
            {
                again = Console.ReadLine();
            }
        }
        while (again=="Y");
    }
}