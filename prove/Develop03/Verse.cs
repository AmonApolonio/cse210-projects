using System.Text.RegularExpressions;

class Verse
{
	private List<int> _visibleWords;
	private List<string> _words;
	private int _verserNumber;

	public Verse(int number, string text)
	{
		_verserNumber = number;
		_words = [.. text.Split(' ')];
		_visibleWords = Enumerable.Range(0, _words.Count()).ToList();
	}
    public Verse Clone()
    {
        return new Verse(_verserNumber, string.Join(" ", _words));
    }
    
	public List<string> GetWords()
	{
		return _words;
	}

	public List<int> GetVisibleWords()
	{
		return _visibleWords;
	}

	public void DisplayWords()
	{
		foreach (string word in _words)
		{
    		Console.Write($"{word} ");
		}
	}

	public int GetVerseNumber()
	{
		return _verserNumber;
	}

	public void HideWord(int index)
	{
		_words[index] = Regex.Replace(_words[index], @".", "_");
		_visibleWords.Remove(index);
	}
}