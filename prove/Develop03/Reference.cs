using System;

namespace References;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    public Reference(string book, int chapter, int start, int end)
    {
        this._book = book;
        this._chapter = chapter;
        this._startVerse = start;
        this._endVerse = end;
    }
    public string Get()
    {
        if (this._startVerse == this._endVerse)
        {
            return $"{this._book} {this._chapter}:{this._startVerse}";
        }
        else
        {
            return $"{this._book} {this._chapter}:{this._startVerse}-{this._endVerse}";
        }
    }
    public void Set(string book, int chapter, int start, int end)
    {
        this._book = book;
        this._chapter = chapter;
        this._startVerse = start;
        this._endVerse = end;
    }
}