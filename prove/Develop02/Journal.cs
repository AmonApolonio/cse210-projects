using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("No entries available to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName, string format)
    {
        string fullPath = $"{fileName}.{format}";

        try
        {
            if (format.ToLower() == "json")
            {
                var json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fullPath, json);
                Console.WriteLine($"Journal saved to {fullPath} in JSON format.");
            }
            else if (format.ToLower() == "csv")
            {
                using StreamWriter writer = new StreamWriter(fullPath);
                writer.WriteLine("Date,Prompt,Entry");
                foreach (Entry entry in _entries)
                {
                    string csvLine = $"{entry.Date},{EscapeCsv(entry.PromptText)},{EscapeCsv(entry.EntryText)}";
                    writer.WriteLine(csvLine);
                }
                Console.WriteLine($"Journal saved to {fullPath} in CSV format.");
            }
            else
            {
                Console.WriteLine("Unsupported format.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    private string EscapeCsv(string input)
    {
        if (input.Contains(",") || input.Contains("\""))
        {
            input = input.Replace("\"", "\"\"");
            return $"\"{input}\"";
        }
        return input;
    }

    public void LoadFromFile(string fileName)
    {
        string fullPath = $"{fileName}.json";
        try
        {
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
                Console.WriteLine("=========================");
                Console.WriteLine($"Journal loaded from {fullPath}.");
            }
            else
            {
                Console.WriteLine("=========================");
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("=========================");
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}
