using System.Text;

var text = new FormattedText("This is a brave new world");

text.GetRange(10, 15).Capitalize = true;

Console.WriteLine(text);

public class FormattedText(string plainText)
{
	private readonly List<TextRange> _formatting = [];

	public TextRange GetRange(int start, int end)
	{
		var range = new TextRange {Start = start, End = end};
		
		_formatting.Add(range);
		
		return range;
	}

	public override string ToString()
	{
		var sb = new StringBuilder();

		for (int i = 0; i < plainText.Length; i++)
		{
			var character = plainText[i];
			
			foreach (var format in _formatting)
			{
				if (format.Covers(i) && format.Capitalize)
				{
					character = char.ToUpperInvariant(character);
				}

				sb.Append(character);
			}
		}
		
		return sb.ToString();
	}

	public class TextRange
	{
		public required int Start, End;
		public bool Capitalize, Bold, Italic;

		public bool Covers(int position)
		{
			return position >= Start && position <= End;
		}
	}
}