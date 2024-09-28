//These classes are only used to configure the JSON structure.

public class ScriptureCollection
{
    public List<ScriptureEntry> scriptures { get; set; }
}

public class ScriptureEntry
{
    public string book { get; set; }
    public int chapter { get; set; }
    public List<VerseEntry> verses { get; set; }
}

public class VerseEntry
{
    public int verseNumber { get; set; }
    public string text { get; set; }
}