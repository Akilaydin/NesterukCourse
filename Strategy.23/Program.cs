using System.Text;

using static System.Console;

var markdownProcessor = new TextProcessor<MarkdownTextProcessingStrategy>();
var htmlProcessor = new TextProcessor<HtmlTextProcessingStrategy>();

markdownProcessor.ProcessText(new []{"foo", "bar", "baz"});
WriteLine(markdownProcessor);

htmlProcessor.ProcessText(new []{"foo", "bar", "baz"});
WriteLine(htmlProcessor);

public class TextProcessor<TStrategy> where TStrategy : ITextProcessingStrategy, new()
{
	private StringBuilder _builder = new();
	//private ITextProcessingStrategy? _textProcessingStrategy = new TStrategy();
	private ITextProcessingStrategy? _textProcessingStrategy = (ITextProcessingStrategy)Activator.CreateInstance(typeof(TStrategy))!;

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