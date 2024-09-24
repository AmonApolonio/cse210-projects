using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        string filePath = "prompts.json";
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                _prompts = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            else
            {
                throw new FileNotFoundException("Prompts file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading prompts: {ex.Message}");
            _prompts = new List<string>();
        }
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "No prompts available.";
        }

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
