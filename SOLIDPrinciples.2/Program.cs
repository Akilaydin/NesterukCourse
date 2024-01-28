// See https://aka.ms/new-console-template for more information

using SOLIDPrinciples.LSP;

using static System.Console;

var rc = new Rectangle(2,3);
PrintWidth(rc);

var sq = new Square(5);
PrintWidth(sq);

static void PrintWidth(Rectangle r)
{
	int width = r.Width;
	r.Height = 10;
	WriteLine($"Expected area of {10 * width}, got {r.Area}");
}