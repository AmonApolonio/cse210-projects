using System.Text.RegularExpressions;

class Scripture
{
	private string _book;
    private int _chapter;
    public List<Verse> _verses = [];

	public Scripture(string book, int chapter)
	{
		_book = book;
        _chapter = chapter;
	}

	public List<Verse> GetVerses()
	{
		return _verses;
	}

	public void SetVerse(int verserNumber, string text)
	{
		_verses.Add(new Verse(verserNumber, text));
	}
	
	public void SetVerses(List<Verse> verses)
	{
		_verses = verses;
	}

    public void HideRandomWords(int wordsToHide)
    {
        Random rnd = new Random();

        foreach (Verse verse in _verses)
        {
            List<int> visibleWords = verse.GetVisibleWords();

            if (visibleWords.Count() > 0)
            {
                int wordsToHideInVerse = Math.Min(wordsToHide, visibleWords.Count);

                for (int i = 0; i < wordsToHideInVerse; i++)
                {
                    visibleWords = verse.GetVisibleWords();
                    if (visibleWords.Count > 0)
                    {
                        int randomIndex = rnd.Next(0, visibleWords.Count);
                        verse.HideWord(visibleWords[randomIndex]);
                    }
                }
            }
        }
    }

 
    public void DisplayReference()
	{
		Reference reference = new Reference(_book, _chapter, _verses);
		Console.Write($"{reference.GetReference()}\n");
	}

	public void DisplayVerses()
	{
		foreach (Verse verse in _verses)
		{
			Console.Write($"{verse.GetVerseNumber()} ");
			verse.DisplayWords();
			Console.WriteLine();
		}
	}

	public bool IsCompletelyHidden()
	{
		string text = "";
    	
		foreach (Verse verse in _verses)
		{
			List<string> words = verse.GetWords();
			text += string.Concat(words);

		}

		return text.All(c => c == '_');
	}
}