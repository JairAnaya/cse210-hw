using System;
using System.Collections.Generic;
using System.IO;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    public Reference Reference => _reference;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            if (!IsCompletelyHidden())
            {
                int indexToHide;
                do
                {
                    indexToHide = random.Next(_words.Count);
                } while (_words[indexToHide].IsHidden());

                _words[indexToHide].Hide();
            }
        }
    }

    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}