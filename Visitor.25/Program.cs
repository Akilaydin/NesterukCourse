using System.Globalization;
using System.Text;

var e = new AdditionExpression(new DoubleExpression(1), new AdditionExpression(new DoubleExpression(2), new DoubleExpression(3))); // 1 + (2 + 3)

var calculator = new ExpressionCalculator();
calculator.Visit(e);
calculator.Print();

public class ExpressionCalculator : IExpressionVisitor
{
	private double _result;
	
	public void Visit(DoubleExpression expression)
	{
		_result = expression.Value;
	}

	public void Visit(AdditionExpression expression)
	{
		expression.Left.AcceptVisitor(this);
		
		var a = _result;
		
		expression.Right.AcceptVisitor(this);
		
		var b = _result;

		_result = a + b;
	}
	
	public void Print() => Console.WriteLine(_result.ToString(CultureInfo.InvariantCulture));
}

public class ExpressionPrinter : IExpressionVisitor
{
	private StringBuilder _builder = new StringBuilder();

	public void Visit(DoubleExpression expression)
	{
		_builder.Append(expression.Value);
	}

	public void Visit(AdditionExpression expression)
	{
		_builder.Append(value: '(');
		expression.Left.AcceptVisitor(this);
		_builder.Append(value: '+');
		expression.Right.AcceptVisitor(this);
		_builder.Append(value: ')');
	}

	public void Print() => Console.WriteLine(_builder.ToString());
}

public abstract class Expression
{
	public abstract void AcceptVisitor(IExpressionVisitor visitor);
}

public interface IExpressionVisitor
{
	void Visit(DoubleExpression expression);
	void Visit(AdditionExpression expression);
}

public class DoubleExpression(double value) : Expression
{
	public readonly double Value = value;

	public override void AcceptVisitor(IExpressionVisitor visitor)
	{
		visitor.Visit(this);
	}
}

public class AdditionExpression(Expression left, Expression right) : Expression
{
	public readonly Expression Right = right;
	public readonly Expression Left = left;

	public override void AcceptVisitor(IExpressionVisitor visitor)
	{
		visitor.Visit(this);
	}
}