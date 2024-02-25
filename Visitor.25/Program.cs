using System.Text;

var e = new AdditionExpression(new DoubleExpression(1), new AdditionExpression(new DoubleExpression(2), new DoubleExpression(3))); // 1 + (2 + 3)

ExpressionPrinter.AppendExpression(e);
ExpressionPrinter.Print();


public class ExpressionPrinter
{
	private static StringBuilder s_builder = new();

	public static void Print()
	{
		Console.WriteLine(s_builder.ToString());
	}
	
	public static void AppendExpression(Expression expression)
	{
		switch (expression)
		{
			case DoubleExpression e:
				s_builder.Append(e.Value);
				break;
			case AdditionExpression e2:
				s_builder.Append(value: '(');
				AppendExpression(e2.Left);
				s_builder.Append(value: '+');
				AppendExpression(e2.Right);
				s_builder.Append(value: ')');
				break;
		}
	}

	public static void Clear() => s_builder.Clear();
}

public abstract class Expression
{
}

public class DoubleExpression(double value) : Expression
{
	public readonly double Value = value;
}

public class AdditionExpression(Expression left, Expression right) : Expression
{
	public readonly Expression Right = right;
	public readonly Expression Left = left;
}