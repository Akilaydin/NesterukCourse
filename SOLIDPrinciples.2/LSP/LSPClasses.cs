namespace SOLIDPrinciples.LSP;

public class Rectangle
{
	public int Width { get; set; }
	public int Height { get; set; }

	public Rectangle() {}

	public Rectangle(int width, int height)
	{
		Width = width;
		Height = height;
	}

	public bool IsSquare => Width == Height;

	public int Area {
		get {
			Console.WriteLine("Area");
			return Width * Height;
		}
	}

	public override string ToString()
	{
		return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
	}
}

public class Square : Rectangle
{
	public new int Height { set => base.Height = base.Width = value; }
	public new int Width  { set => base.Height = base.Width = value; }

	public Square(int side)
	{
		Width = Height = side;
	}
}
