// See https://aka.ms/new-console-template for more information

var apple = new Product(name: "Apple", color: Color.Green, size: Size.Small);
var tree = new Product(name: "Tree", color: Color.Green, size: Size.Large);
var house = new Product(name: "House", color: Color.Blue, size: Size.Large);

Product[] products = { apple, tree, house };

var betterFilter = new GoodProductFilter();

var t = new ColorSpecification { TargetColor = Color.Green } & new SizeSpecification { TargetSize = Size.Large };

foreach (var product in betterFilter.Filter(products, t))
{
	Console.WriteLine(product);
}

public enum Color
{
	Red, Green, Blue
}

public enum Size
{
	Small, Medium, Large, Yuge
}

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

public class BadProductFilter
{
	public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
	{
		foreach (var p in products)
		{
			if (p.Color == color)
			{
				yield return p;
			}
		}
	}
}

internal interface IFilter<T>
{
	public IEnumerable<T> Filter(IEnumerable<T> items, BaseSpecification<T> specification);
}

internal class GoodProductFilter : IFilter<Product>
{
	public IEnumerable<Product> Filter(IEnumerable<Product> items, BaseSpecification<Product> specification)
	{
		foreach (var item in items)
		{
			if (specification.IsSatisfied(item))
			{
				yield return item;
			}
		}
	}
}

internal abstract class BaseSpecification<T>
{
	public abstract bool IsSatisfied(T item);

	public static BaseSpecification<T> operator &(BaseSpecification<T> left, BaseSpecification<T> right)
	{
		return new CompositeSpecification<T> {
			Specifications = [left, right]
		};
	}
}

class CompositeSpecification<T> : BaseSpecification<T>
{
	public required BaseSpecification<T>[] Specifications { get; init; }
	
	public override bool IsSatisfied(T item)
	{
		return Specifications.All(s => s.IsSatisfied(item));
	}
}

internal class ColorSpecification : BaseSpecification<Product>
{
	public required Color TargetColor { get; init; }

	public override bool IsSatisfied(Product item)
	{
		return item.Color == TargetColor;
	}
}

internal class SizeSpecification : BaseSpecification<Product>
{
	public required Size TargetSize { get; init; }

	public override bool IsSatisfied(Product item)
	{
		return item.Size == TargetSize;
	}
}