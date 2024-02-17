#region
using System.Text;
#endregion

var expression = "(13+4)-(12+1)";
var tokens = Lex(expression);
Console.WriteLine(string.Join("\t", tokens));

var parsed = Parse(tokens);
Console.WriteLine($"{expression} = {parsed.Value}");
static IElement Parse(IReadOnlyList<Token> tokens)
{
	var result = new BinaryOperation();
	var haveLhs = false;
	for (var i = 0; i < tokens.Count; i++)
	{
		var token = tokens[i];

		switch (token.TokenType)
		{
			case Token.Type.Integer:
				var integer = new Integer(int.Parse(token.Text));
				if (!haveLhs)
				{
					result.Left = integer;
					haveLhs = true;
				}
				else
				{
					result.Right = integer;
				}
				break;
			case Token.Type.Plus:
				result.OperationType = OperationType.Addition;
				break;
			case Token.Type.Minus:
				result.OperationType = OperationType.Subtraction;
				break;
			case Token.Type.Lparen:
				var j = i;
				for (; j < tokens.Count; ++j)
				{
					if (tokens[j].TokenType == Token.Type.Rparen)
					{
						break;
					}
				}

				var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
				var element = Parse(subexpression);
				if (!haveLhs)
				{
					result.Left = element;
					haveLhs = true;
				}
				else
				{
					result.Right = element;
				}
				i = j;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
	return result;
}

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
			for (var j = i + 1; j < input.Length; ++j)
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

public interface IElement
{
	int Value { get; }
}

public class Integer(int value) : IElement
{
	public int Value => value;
}

public enum OperationType
{
	Addition, Subtraction
}

public class BinaryOperation : IElement
{
	public OperationType OperationType;
	public IElement Left;
	public IElement Right;

	public int Value => CalculateValue();

	private int CalculateValue()
	{
		return OperationType switch {
			OperationType.Addition => Left.Value + Right.Value,
			OperationType.Subtraction => Left.Value - Right.Value,
			_ => throw new ArgumentException()
		};
	}
}

public class Token
{
	public enum Type
	{
		Integer, Plus, Minus, Lparen, Rparen
	}

	public Type TokenType;
	public string Text;

	public Token(Type type, string text)
	{
		TokenType = type;
		Text = text;
	}

	public override string ToString()
	{
		return $"`{Text}`";
	}
}
