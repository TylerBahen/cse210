namespace Words;
using System.Text.RegularExpressions;

public class Word
{
    private string _text;
    private bool _isHidden;
    private string _hiddenText;
    public Word(string text)
    {
        this._isHidden = false;
        this._text = text;
        //Disclaimer: I used AI to generate this Regex
        this._hiddenText = Regex.Replace(this._text, @"\p{L}", "_");
    }
    public void Hide()
    {
        this._isHidden = true;
    }
    public string GetDisplayString()
    {
        if (this._isHidden)
        {
            return this._hiddenText;
        }
        else
        {
            return this._text;
        }
    }
}