using static System.Console;

var image = new LazyBitmap("Pokemon.png");

DrawImage(image);

static void DrawImage(IBitmap img)
{
	WriteLine("Preparing to draw");
	img.Draw();
	WriteLine("Done drawing");
}

internal interface IBitmap
{
	void Draw();
}

class LazyBitmap(string fileName) : IBitmap
{
	private Bitmap? _bitmap = null!;

	public void Draw()
	{
		_bitmap ??= new Bitmap(fileName);

		_bitmap.Draw();
	}
}

class Bitmap : IBitmap
{
	private readonly string _fileName;
	public Bitmap(string fileName)
	{
		_fileName = fileName;
		WriteLine("Loading image from filename " + _fileName);
	}

	public void Draw()
	{
		WriteLine("Drawing image " + _fileName);
	}
}