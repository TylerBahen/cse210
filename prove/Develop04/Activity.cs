namespace Activites;
using System.Runtime.InteropServices;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void ShowPrologue()
    {
        Console.Clear();
        Console.WriteLine(_description);
        ShowSpinner(7);
        Console.Clear();
    }
    public void ShowSpinner(int time)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        Console.Write(" ");
        int index = 0;
        for (int i = 0; i<time*10; i++)
        {
            Console.Write($"\b{spinner[index]}");

            index = (index + 1) % spinner.Length;

            Thread.Sleep(100);
        }

        Console.Write("\b ");
        Console.WriteLine();
    }
    public virtual void ShowEpilogue()
    {
        Console.Clear();
        int minutes = _duration/60;
        int seconds = _duration%60;
        Console.WriteLine($"Thank you for participating in this {this._name}. It lasted {minutes}:{seconds}.");
        ShowSpinner(7);
        Console.Clear();
    }
}

public class Breathing : Activity
{
    public Breathing() :  base("Breathing Activity","This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        ShowPrologue();
        Console.WriteLine("How long would you like to breathe for?");
        string durationRaw = Console.ReadLine();
        if (int.TryParse(durationRaw, out _duration))
        {
            Start();
        } 
        else
        {
            Console.WriteLine("Number not recognized");
        }
    }
    public void Start()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        Console.Clear();
        while (DateTime.Now < endTime) {
            BreatheIn(6);
            if (DateTime.Now < endTime)
            {
                BreatheOut(6);
            }
        }
        ShowEpilogue();
    }
    public void BreatheIn(int duration)
    {
        Console.Write("Breathe In...");
        ShowSpinner(duration);
        Console.Clear();
    }
    public void BreatheOut(int duration)
    {
        Console.Write("Breathe Out...");
        ShowSpinner(duration);
        Console.Clear();
    }
}

public class Reflection : Activity
{
    private Random random = new Random();
    private string _prompt;
    private List<string> _prompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];
    private List<string> _questions = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];
    private List<string> _remainingQuestions;
    public Reflection() : base("Reflection Activity","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life")
    {
        ShowPrologue();
        Console.WriteLine("How long would you like to reflect for?");
        string durationRaw = Console.ReadLine();
        if (int.TryParse(durationRaw, out _duration))
        {
            Start();
        } 
        else
        {
            Console.WriteLine("Number not recognized");
        }
    }
    public void Start()
    {
        _prompt = _prompts[random.Next(_prompts.Count)];
        Console.Clear();
        Console.Write(_prompt);
        ShowSpinner(5);
        Console.Clear();
        ShowSpinner(1);
        _remainingQuestions = _questions;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            displayQuestion();
        }
        ShowEpilogue();
    }
    public void displayQuestion()
    {
        if (_remainingQuestions.Count < 1)
        {
            _remainingQuestions = _questions;
        }
        int index = Random.Shared.Next(_remainingQuestions.Count);
        string question = _remainingQuestions[index];
        _remainingQuestions.RemoveAt(index);
        Console.Clear();
        Console.Write(question);
        ShowSpinner(10);
    }
}

public class Listing : Activity
{
    private Random random = new Random();
    private string _prompt;
    private List<string> answers = new List<string>();
    private List<string> _prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];
    public Listing() : base("Listing Activity","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        ShowPrologue();
        Console.WriteLine("How long would you like to reflect for?");
        string durationRaw = Console.ReadLine();
        if (int.TryParse(durationRaw, out _duration))
        {
            Start();
        } 
        else
        {
            Console.WriteLine("Number not recognized");
        }
    }
    public void Start()
    {
        _prompt = _prompts[random.Next(_prompts.Count)];
        Console.Clear();
        Console.Write($"{_prompt}\nThink...");
        ShowSpinner(5);
        answers = [];
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Console.Write($"{_prompt}\nAnswer:\n");
            answers.Add(Console.ReadLine());
        }
        ShowEpilogue();
    }
    public override void ShowEpilogue()
    {
        Console.Clear();
        int minutes = _duration/60;
        int seconds = _duration%60;
        Console.WriteLine($"Thank you for participating in this {this._name}. It lasted {minutes}:{seconds} and you listed {answers.Count} items.");
        ShowSpinner(3);
        Console.Clear();
    }
}