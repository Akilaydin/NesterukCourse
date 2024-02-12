#region
using System.Drawing;
#endregion

var circle = new Circle(2);

var redCircle = new ColoredShape<Circle> { Color = Color.Green};
var redTransparentCircle = new TransparentShape<ColoredShape<Circle>> { TransparencyValue = 0.65f};

Console.WriteLine(circle.AsString()); 
Console.WriteLine(redCircle.AsString());
Console.WriteLine(redTransparentCircle.AsString());

public abstract class Shape
{
	public virtual string AsString() => string.Empty;
}

public class ColoredShape<T> : Shape where T : Shape, new()
{
	public Color Color;
	private readonly Shape _shape = new T();

	public override string AsString() => $"Colored shape with color of {Color.ToString()} and shape itself is {_shape.AsString()}";
}

public class TransparentShape<T> : Shape where T : Shape, new()
{
	public float TransparencyValue;
	private readonly Shape _shape = new T();
	
	public override string AsString() => $"Transparent shape with transparency of {TransparencyValue * 100.0f} and shape itself is {_shape.AsString()}";
}

public sealed class Circle(float radius) : Shape
{

	public Circle() : this(0)
	{
      
	}

	public void Resize(float factor)
	{
		radius *= factor;
	}

	public override string AsString() => $"A circle of radius {radius}";
}
public sealed class Square(float side) : Shape
{
	public Square() : this(0)
	{
      
	}

	public override string AsString() => $"A square with side {side}";
}