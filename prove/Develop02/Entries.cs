namespace Entries;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public void Display()
    {
        Console.WriteLine($"Date: {this._date} - Prompt: {this._prompt}\n{this._response}");
    }
    public void Edit()
    {
        Console.WriteLine($"Your old entry:\nDate: {this._date} - Prompt: {this._prompt}\n{this._response}\n\nNew Entry:");
        string overwrite = Console.ReadLine();
        this._response = overwrite;
    }
}