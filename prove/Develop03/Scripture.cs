namespace Scriptures;
using Words;
using References;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private int _wordCount;
    private List<int> _hiddenList;
    public Scripture(string rawText, Reference reference)
    {
        this._words = new List<Word>();
        this._reference = reference;
        string[] wordList = rawText.Split(" ");
        this._wordCount = wordList.Length;
        this._hiddenList = new List<int>();
        foreach (string wordRaw in wordList)
        {
            this._words.Add(new Word(wordRaw));
        }
    }
    public void Display()
    {
        string outText = "";
        foreach (Word word in this._words)
        {
            outText+=word.GetDisplayString();
            outText+=" ";
        }
        Console.Clear();
        Console.WriteLine($"{this._reference.Get()}\n{outText}");
    }
    public void HideRandomWord()
    {
        //I'm pretty proud of this clever math I did
        Random random = new Random();
        int rand = random.Next(0,this._wordCount-this._hiddenList.Count);
        this._hiddenList.Sort();
        foreach (int i in this._hiddenList)
        {
            if (rand >= i)
            {
                rand+=1;
            }
        }
        this._words[rand].Hide();
        this._hiddenList.Add(rand);
    }
    public bool IsTotallyHidden()
    {
        return this._hiddenList.Count>=this._wordCount;
    }
}