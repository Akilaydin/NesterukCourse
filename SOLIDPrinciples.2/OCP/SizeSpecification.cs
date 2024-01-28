internal class SizeSpecification : BaseSpecification<Product>
{
	public required Size TargetSize { get; init; }

	public override bool IsSatisfied(Product item)
	{
		return item.Size == TargetSize;
	}
}