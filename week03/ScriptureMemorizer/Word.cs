using System;
using System.Text;

public class Word
{
    // Private fields
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Public getter
    public string Text
    {
        get { return _text; }
    }

    // Checks whether the word is considered hidden
    public bool IsHidden
    {
        get { return _isHidden; }
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Returns length of only letter characters
    public int LetterCount()
    {
        int count = 0;
        foreach (char c in _text)
        {
            if (Char.IsLetter(c))
            {
                count++;
            }
        }
        return count;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        var sb = new StringBuilder(_text.Length);
        foreach (char c in _text)
        {
            if (Char.IsLetter(c))
            {
                sb.Append('_');
            }
            else
            {                
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
