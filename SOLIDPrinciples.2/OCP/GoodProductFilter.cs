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