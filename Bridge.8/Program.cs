

public interface IRenderer
{
	void RenderCircle(float radius);
}

public class VectorRenderer : IRenderer
{
	public void RenderCircle(float radius)
	{
		Console.WriteLine($"Drawing a circle of radius {radius}");
	}
}

public class RasterRenderer : IRenderer
{
	public void RenderCircle(float radius)
	{
		Console.WriteLine($"Drawing pixels for circle of radius {radius}");
	}
}

public abstract class Shape(IRenderer renderer)
{
	protected readonly IRenderer Renderer = renderer;

	public abstract void Draw();
	public abstract void Resize(float factor);
}

public class Circle(IRenderer renderer, float radius) : Shape(renderer)
{

	public override void Draw()
	{
		Renderer.RenderCircle(radius);
	}

	public override void Resize(float factor)
	{
		radius *= factor;
	}
}
