namespace Journals;
using Entries;
using System;

public class Journal
{
    public List<Entry> _entries = new();
    public string _name;
    public void AddEntry()
    {
        var date = DateTime.Now.ToString("MM/dd/yyyy");
        string prompt = GeneratePrompt();
        Console.WriteLine($"Prompt: {prompt}");
    
        Console.Write("Response: ");
        var response = Console.ReadLine();

        var toAdd = new Entry();
        toAdd._date = date;
        toAdd._prompt = prompt;
        toAdd._response = response;
        _entries.Add(toAdd);
    }
    public void DisplayEntries()
    {
        int index = 0;
        Console.WriteLine("\n--------------------\n");
        foreach (var entry in this._entries)
        {
            Console.WriteLine(index);
            entry.Display();
            Console.WriteLine("\n--------------------\n");
            index++;
        }
    }
    public void SaveJournal()
    {
        while (string.IsNullOrEmpty(this._name))
        {
            Console.WriteLine("Name Your Journal: (one word, no special characters)");
            string nameRaw = Console.ReadLine();
            if (!nameRaw.Contains(" "))
            {
                this._name = nameRaw.ToLower();
            }
        }
        List<string> entriesCooked = new List<string>();
        foreach (var entry in this._entries)
        {
            entriesCooked.Add($"{entry._date}~{entry._prompt}~{entry._response}");
        }
        File.WriteAllLines($"{this._name}.csv",entriesCooked);
        Console.WriteLine($"Journal saved as '{this._name}'");
    }
    public string GeneratePrompt()
    {
        List<string> prompts = new List<string> {
            "Who was the most interresting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing I took for granted today?",
            "What is something I noticed today I don't normally notice?",
            "What is one thing I wouldn't change about today?",
            "How could I make tomorrow better than today?"
        };
        var random = new Random();
        string pick = prompts[random.Next(prompts.Count)];
        return pick;
    }
}