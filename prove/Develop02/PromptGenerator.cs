using System;
using System.Collections.Generic;
using System.IO;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    private string filename = "prompts.txt";
    private Random randomPrompt = new Random();
    
    public void LoadPrompts()
    {
        if (_prompts.Count == 0)
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
        }
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            throw new InvalidOperationException("No prompts available. Please load prompts first.");
        }
        int index = randomPrompt.Next(_prompts.Count);
        return _prompts[index];
    }
}