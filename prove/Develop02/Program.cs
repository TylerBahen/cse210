using System;
using Entries;
using Journals;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        Console.WriteLine("Welcome to Journal!\n1 - Write\n2 - Display\n3 - Edit\n4 - Load\n5 - Save\n6 - Quit");
        int running = 1;
        while (running == 1)
        {
            Console.Write('>');
            string command = Console.ReadLine();
            if (command == "1")
            {
                journal.AddEntry();
            }
            if (command == "2")
            {
                journal.DisplayEntries();
            }
            if (command == "3")
            {
                journal.DisplayEntries();
                Console.WriteLine("What is the number of the entry you would like to edit?");
                int index = int.Parse(Console.ReadLine());
                journal._entries[index].Edit();
            }
            if (command == "4")
            {
                Console.WriteLine("What is the name of your journal?");
                string nameFind = Console.ReadLine();
                string journalRaw = File.ReadAllText($"{nameFind}.csv");
                string[] entriesRaw = journalRaw.Split("\n");
                foreach (var line in entriesRaw)
                {
                    var newEntry = new Entry();
                    string[] entryRaw = line.Split("~");
                    if (entryRaw.Length==3){
                        newEntry._date = entryRaw[0];
                        newEntry._prompt = entryRaw[1];
                        newEntry._response = entryRaw[2];
                        journal._entries.Add(newEntry);
                    }
                }
                journal._name = nameFind;
                Console.WriteLine($"Journal '{journal._name}' imported");
            }
            if (command == "5")
            {
                journal.SaveJournal();
            }
            if (command == "6")
            {
                running = 0;
            }
        }
    }
}