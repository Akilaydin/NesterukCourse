internal class ColorSpecification : BaseSpecification<Product>
{
	public required Color TargetColor { get; init; }

	public override bool IsSatisfied(Product item)
	{
		return item.Color == TargetColor;
	}
}