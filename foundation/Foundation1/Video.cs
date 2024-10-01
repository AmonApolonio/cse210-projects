class Video
{
	private string _author;
	private List<Comment> _comments;
	private int _length;
	private string _title;

	public Video(string author, int length, string title)
	{
		_author = author;
		_comments = new List<Comment>();
		_length = length;
		_title = title;
	}

	public void DisplayDetails()
	{
        Console.WriteLine($"\n==================\n");
		Console.WriteLine($"Title: {_title}");
		Console.WriteLine($"Author: {_author}");
		Console.WriteLine($"Length: {_length}");
		Console.WriteLine($"\n==== COMMENTS ====\n");
		Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

		foreach (Comment comment in _comments)
		{
			Console.WriteLine($"@{comment.GetAuthor()}:");
			Console.WriteLine(comment.GetText());
			Console.WriteLine();
		}
	}

	public void AddComment(Comment comment)
	{
		_comments.Add(comment);
	}

	public int GetNumberOfComments()
	{
		return _comments.Count;
	}
}