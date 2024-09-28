using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public PromptGenerator Prompt = new PromptGenerator();

    public void AddEntry()
    {
        string prompt0 = Prompt.GetRandomPrompt();
        Console.WriteLine(prompt0);
        Console.Write("> ");
        
        Entry entry = new Entry();
        entry.SetDate();
        entry._entryText = Console.ReadLine();
        entry._promptText = prompt0;
        
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.Display());
        }
    }

    public void SaveToFile()
    {
        Console.WriteLine("What is the filename (adding extension [.csv / .txt])?");
        string file = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                string date = EscapeCsv(entry._date);
                string prompt = EscapeCsv(entry._promptText);
                string text = EscapeCsv(entry._entryText);
                outputFile.WriteLine($"{date},{prompt},{text}");
            }
        }
    }

    private string EscapeCsv(string value)
    {
        if (value.Contains("\"") || value.Contains(","))
        {
            value = value.Replace("\"", "\"\"");
            value = $"\"{value}\"";
        }
        return value;
    }


    public void LoadFromFile()
    {
        Console.WriteLine("What is the filename (adding extension [.csv / .txt])?");
        string file = Console.ReadLine();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = ParseCsv(line);

            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };

                _entries.Add(entry);
            }
            else
            {
                Console.WriteLine("Invalid entry format, skipping line.");
            }
        }
    }

    private string[] ParseCsv(string line)
    {
        var result = new List<string>();
        var currentField = string.Empty;
        var insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                result.Add(currentField);
                currentField = string.Empty;
            }
            else
            {
                currentField += c;
            }
        }

        result.Add(currentField);

        for (int i = 0; i < result.Count; i++)
        {
            result[i] = result[i].Replace("\"\"", "\"");
            if (result[i].StartsWith("\"") && result[i].EndsWith("\""))
            {
                result[i] = result[i][1..^1];
            }
        }

        return result.ToArray();
    }

}