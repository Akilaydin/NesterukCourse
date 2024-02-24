using System.Text;

using static System.Console;

var tp = new TextProcessor();

tp.SetTextProcessingFormat(TextProcessingFormat.Markdown);
tp.ProcessText(new []{"foo", "bar", "baz"});
WriteLine(tp);

tp.Clear();

tp.SetTextProcessingFormat(TextProcessingFormat.Html);
tp.ProcessText(new []{"foo", "bar", "baz"});
WriteLine(tp);

public class TextProcessor
{
	private StringBuilder _builder = new();
	private ITextProcessingStrategy? _textProcessingStrategy;

	public void SetTextProcessingFormat(TextProcessingFormat format)
	{
		switch (format)
		{
			case TextProcessingFormat.Markdown:
				_textProcessingStrategy = new MarkdownTextProcessingStrategy();
				break;
			case TextProcessingFormat.Html:
				_textProcessingStrategy = new HtmlTextProcessingStrategy();
				break;
		}
	}

	public void Clear()
	{
		_builder.Clear();
	}
	
	public void ProcessText(IEnumerable<string> items)
	{
		_textProcessingStrategy.Start(_builder);
		foreach (var item in items)
		{
			_textProcessingStrategy.ProcessItem(_builder, item);
		}
		_textProcessingStrategy.End(_builder);
	}

	public override string ToString()
	{
		return _builder.ToString();
	}
}

public interface ITextProcessingStrategy
{
	void Start(StringBuilder sb);
	void End(StringBuilder sb);
	void ProcessItem(StringBuilder sb, string item);
}

public class MarkdownTextProcessingStrategy : ITextProcessingStrategy
{
	public void Start(StringBuilder sb) { }

	public void End(StringBuilder sb) { }

	public void ProcessItem(StringBuilder sb, string item)
	{
		sb.AppendLine($" * {item}");
	}
}
public class HtmlTextProcessingStrategy : ITextProcessingStrategy
{
	public void Start(StringBuilder sb) => sb.AppendLine("<ul>");

	public void End(StringBuilder sb) => sb.AppendLine("</ul>");

	public void ProcessItem(StringBuilder sb, string item)
	{
		sb.AppendLine($"  <li>{item}</li>");
	}
}

public enum TextProcessingFormat
{
	Markdown,
	Html
}