using System.Text;

var expression = "(13+4)-(12+1)";
var tokens = Lex(expression);
Console.WriteLine(string.Join("\t", tokens));
Console.WriteLine(tokens.Count);

List<Token> Lex(string input)
{
	var result = new List<Token>();

	for (var i = 0; i < input.Length; i++)
	{
		if (input[i] == '+')
		{
			result.Add(new Token(Token.Type.Plus, "+"));
		}
		else if (input[i] == '-')
		{
			result.Add(new Token(Token.Type.Minus, "-"));
		}
		else if (input[i] == '(')
		{
			result.Add(new Token(Token.Type.Lparen, "("));
		}
		else if (input[i] == ')')
		{
			result.Add(new Token(Token.Type.Rparen, ")"));
		}
		else
		{
			var sb = new StringBuilder(input[i].ToString());
			for (int j = i + 1; j < input.Length; ++j)
			{
				if (char.IsDigit(input[j]))
				{
					sb.Append(input[j]);
					++i;
				}
				else
				{
					result.Add(new Token(Token.Type.Integer, sb.ToString()));
					break;
				}
			}
		}
	}
	
	return result;
}

public class Token
{
	public enum Type
	{
		Integer, Plus, Minus, Lparen, Rparen
	}

	public Type MyType;
	public string Text;

	public Token(Type type, string text)
	{
		MyType = type;
		Text = text;
	}

	public override string ToString()
	{
		return $"`{Text}`";
	}
}
