using System.Globalization;
using System.Text;

var e = new AdditionExpression(new DoubleExpression(1), new AdditionExpression(new DoubleExpression(2), new DoubleExpression(3))); // 1 + (2 + 3)

var calculator = new ExpressionPrinter();
calculator.Visit(e);
calculator.Print();

public class ExpressionPrinter : IVisitor, IVisitor<Expression>, IVisitor<DoubleExpression>, IVisitor<AdditionExpression>
{
	private StringBuilder _builder = new StringBuilder();

	public void Visit(Expression visitable) { }

	public void Visit(DoubleExpression visitable)
	{
		_builder.Append(visitable.Value);
	}

	public void Visit(AdditionExpression visitable)
	{
		_builder.Append(value: '(');
		visitable.Left.AcceptVisitor(this);
		_builder.Append(value: '+');
		visitable.Right.AcceptVisitor(this);
		_builder.Append(value: ')');
	}

	public void Print() => Console.WriteLine(_builder.ToString());
}

public abstract class Expression
{
	public virtual void AcceptVisitor(IVisitor visitor)
	{
		if (visitor is IVisitor<Expression> typedVisitor)
		{
			typedVisitor.Visit(this);
		}
	}
}

public interface IVisitor<TVisitable>
{
	void Visit(TVisitable visitable);
}

public interface IVisitor; //Marker interface

public class DoubleExpression(double value) : Expression
{
	public readonly double Value = value;

	public override void AcceptVisitor(IVisitor visitor)
	{
		if (visitor is IVisitor<DoubleExpression> typedVisitor)
		{
			typedVisitor.Visit(this);
		}
	}
}

public class AdditionExpression(Expression left, Expression right) : Expression
{
	public readonly Expression Right = right;
	public readonly Expression Left = left;

	public override void AcceptVisitor(IVisitor visitor)
	{
		if (visitor is IVisitor<AdditionExpression> typedVisitor)
		{
			typedVisitor.Visit(this);
		}
	}
}