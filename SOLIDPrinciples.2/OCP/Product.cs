public class Product(string name, Color color, Size size)
{
	public readonly string Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
	public readonly Color Color = color;
	public readonly Size Size = size;

	public override string ToString()
	{
		return Name;
	}
}