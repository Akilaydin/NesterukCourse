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