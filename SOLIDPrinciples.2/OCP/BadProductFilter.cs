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