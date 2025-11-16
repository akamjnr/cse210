using System;

public class Reference
{
    // Private fields
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Public properties
    public string Book { get { return _book; } }
    public int Chapter { get { return _chapter; } }
    public int StartVerse { get { return _startVerse; } }
    public int EndVerse { get { return _endVerse; } }

    // Constructor for single verse (e.g., John 3:16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for verse range (e.g., Proverbs 3:5-6)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        if (endVerse < startVerse)
        {
            throw new ArgumentException("End verse cannot be less than start verse.");
        }

        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Returns formatted reference as a string
    public override string ToString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
