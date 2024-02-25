using System.Text;

var e = new AdditionExpression(new DoubleExpression(1), new AdditionExpression(new DoubleExpression(2), new DoubleExpression(3))); // 1 + (2 + 3)

var sb = new StringBuilder();
e.Print(sb);

Console.WriteLine(sb.ToString());

public abstract class Expression
{
	public abstract void Print(StringBuilder sb);
}

public class DoubleExpression(double value) : Expression
{
	public override void Print(StringBuilder sb)
	{
		sb.Append(value);
	}
}

public class AdditionExpression(Expression left, Expression right) : Expression
{
	public override void Print(StringBuilder sb)
	{
		sb.Append(value: '(');
		left.Print(sb);
		sb.Append(value: '+');
		right.Print(sb);
		sb.Append(value: ')');
	}
}