internal interface IFilter<T>
{
	public IEnumerable<T> Filter(IEnumerable<T> items, BaseSpecification<T> specification);
}