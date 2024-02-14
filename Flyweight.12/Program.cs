using System.Text;

var text = new FormattedText("This is a brave new world");

text.GetRange(10, 15).Capitalize = true;

Console.WriteLine(text);

public class FormattedText(string plainText)
{
	private readonly List<TextRange> _formatting = [];
	private static readonly TextRangePool RangePool = new();

	public TextRange GetRange(int start, int end)
	{
		var range = RangePool.GetTextRange(start, end, false, false, false);
		_formatting.Add(range);
		return range;
	}

	public override string ToString()
	{
		var sb = new StringBuilder();

		for (int i = 0; i < plainText.Length; i++)
		{
			var charAdded = false;
			foreach (var format in _formatting)
			{
				if (format.Covers(i))
				{
					var character = format.Capitalize ? char.ToUpperInvariant(plainText[i]) : plainText[i];
					sb.Append(character);
					charAdded = true;
					break;
				}
			}
			if (!charAdded)
			{
				sb.Append(plainText[i]);
			}
		}

		return sb.ToString();
	}
}


public class TextRange
{
	public required int Start, End;
	public required bool Capitalize, Bold, Italic;

	public bool Covers(int position)
	{
		return position >= Start && position <= End;
	}
}

public class TextRangePool
{
	private readonly List<TextRange> _pool = [];

	public TextRange GetTextRange(int start, int end, bool capitalize, bool bold, bool italic)
	{
		var existingRange = _pool.FirstOrDefault(tr => tr.Start == start && tr.End == end 
			&& tr.Capitalize == capitalize && tr.Bold == bold 
			&& tr.Italic == italic);
		if (existingRange != null)
		{
			return existingRange;
		}

		var newTextRange = new TextRange
		{
			Start = start, 
			End = end, 
			Capitalize = capitalize, 
			Bold = bold, 
			Italic = italic
		};
		_pool.Add(newTextRange);
		return newTextRange;
	}
}