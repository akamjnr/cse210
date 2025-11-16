using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Scripture
{
    // Private fields
    private Reference _reference;
    private List<Word> _words;

    // Public accessors
    public Reference Reference { get { return _reference; } }
    public IReadOnlyList<Word> Words { get { return _words.AsReadOnly(); } }

    // Constructors
    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        _words = ParseTextToWords(text);
    }

    // Parse the scripture text into Word objects.
    private List<Word> ParseTextToWords(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));

        // Split on spaces while preserving punctuation in the tokens.
        var tokens = Regex.Split(text.Trim(), @"\s+");
        var list = new List<Word>();

        foreach (var t in tokens)
        {
            if (t.Length > 0)
            {
                list.Add(new Word(t));
            }
        }

        return list;
    }

    // Returns the full scripture display
    public string GetDisplayText()
    {
        string wordsJoined = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.ToString()}\n{wordsJoined}";
    }

    // Hide up to count words at random.
    public int HideRandomWords(int count, Random rng)
    {
        if (rng == null) rng = new Random();

        var notHidden = _words.Where(w => !w.IsHidden && w.LetterCount() > 0).ToList();
        if (notHidden.Count == 0) return 0;

        int toHide = Math.Min(count, notHidden.Count);

        var shuffled = notHidden.OrderBy(x => rng.Next()).ToList();

        for (int i = 0; i < toHide; i++)
        {
            shuffled[i].Hide();
        }

        return toHide;
    }

    // Returns true if all words with letters are hidden
    public bool AllHidden()
    {
        return _words.Where(w => w.LetterCount() > 0).All(w => w.IsHidden);
    }
}
