#region
using System.Text;
#endregion

var drawing = new GraphicObject {Name = "My Drawing"};

drawing.Children.Add(new Square {Color = "Red"});
drawing.Children.Add(new Circle{Color="Yellow"});
      
var group = new GraphicObject {
	Name = "Sub group"
};

group.Children.Add(new Circle{Color="Blue"});
group.Children.Add(new Square{Color="Blue"});

drawing.Children.Add(group);

Console.WriteLine(drawing);

internal class GraphicObject
{
	public virtual string Name { get; set; } = "Group";
	public List<GraphicObject> Children => _children.Value;

	public string Color;

	private Lazy<List<GraphicObject>> _children = new(() => []);

	public override string ToString()
	{
		var sb = new StringBuilder();
		Print(sb, 0);
		return sb.ToString();
	}

	private void Print(StringBuilder sb, int depth)
	{
		sb.Append(new string('*', depth)).Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ").AppendLine($"{Name}");
		foreach (var child in Children)
		{
			child.Print(sb, depth + 1);
		}
	}
}

internal class Square : GraphicObject
{
	public override string Name => nameof(Square);
}

internal class Circle : GraphicObject
{
	public override string Name => nameof(Circle);
}
