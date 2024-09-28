class Reference
{
	private string _book;
	private int _chapter;
	private string _reference;

	public Reference(string book, int chapter, List<Verse> verses)
	{
		_book = book;
		_chapter = chapter;
		_reference = GeneratesReference(verses);
		
	}

	public string GetReference()
	{
		return $"{_book} {_chapter}:{_reference}\n";
	}

	private static string GeneratesReference(List<Verse> verses)
	{
		string reference = "";
		List<int> consecutives = new List<int>();

		if (verses.Count == 1)
		{
			return verses[0].GetVerseNumber().ToString();
		}
		

		for (int i = 0; i < verses.Count - 1; i++)
		{
			int nextVerseNumber = verses[i + 1].GetVerseNumber();

			if (nextVerseNumber != verses[i].GetVerseNumber() + 1)
			{
				if (consecutives.Count > 0)
				{
					consecutives.Add(verses[i].GetVerseNumber());
					reference += $"{consecutives[0]} - {consecutives[^1]}, ";
					consecutives.Clear();
				}
				else
				{
					reference += $"{verses[i].GetVerseNumber()}, ";
				}
			}
			else
			{
				consecutives.Add(verses[i].GetVerseNumber());
				if (i == verses.Count - 2)
				{
					reference += $"{consecutives[0]} - ";
				}
			}
		}
		reference += verses.Last().GetVerseNumber();
		return reference;
	}
}