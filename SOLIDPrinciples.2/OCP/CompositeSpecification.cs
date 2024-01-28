class CompositeSpecification<T> : BaseSpecification<T>
{
	public required BaseSpecification<T>[] Specifications { get; init; }
	
	public override bool IsSatisfied(T item)
	{
		return Specifications.All(s => s.IsSatisfied(item));
	}
}