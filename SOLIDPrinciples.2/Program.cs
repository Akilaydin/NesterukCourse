// See https://aka.ms/new-console-template for more information

using static System.Console;

var apple = new Product(name: "Apple", color: Color.Green, size: Size.Small);
var tree = new Product(name: "Tree", color: Color.Green, size: Size.Large);
var house = new Product(name: "House", color: Color.Blue, size: Size.Large);

Product[] products = { apple, tree, house };

var betterFilter = new GoodProductFilter();

var t = new ColorSpecification { TargetColor = Color.Green } & new SizeSpecification { TargetSize = Size.Large };

foreach (var product in betterFilter.Filter(products, t))
{
	WriteLine(product);
}