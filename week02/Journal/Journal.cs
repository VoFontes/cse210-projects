using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }
    public void LoadFromFile(string filename)
{
    string[] lines = File.ReadAllLines(filename);

    _entries.Clear();

    foreach (string line in lines)
    {
        string[] parts = line.Split("|");

        Entry newEntry = new Entry();

        newEntry._date = parts[0];
        newEntry._promptText = parts[1];
        newEntry._entryText = parts[2];

        _entries.Add(newEntry);
    }
}
}