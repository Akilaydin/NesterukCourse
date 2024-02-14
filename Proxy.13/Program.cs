Console.WriteLine(10m * 7.Percent());
Console.WriteLine(2m.Percent() * 2m.Percent());

public struct Percentage(decimal value) : IEquatable<Percentage>
{
	private readonly decimal _value = value;

	public static implicit operator Percentage(int value)
	{
		return value.Percent();
	}

	public static decimal operator *(decimal a, Percentage b)
	{
		return b._value * a;
	}

	public static Percentage operator *(Percentage a, Percentage b)
	{
		return (a._value * b._value).Percent();
	}

	public override string ToString()
	{
		return $"{_value * 100}%";
	}

	public bool Equals(Percentage other)
	{
		return _value == other._value;
	}
	public override bool Equals(object? obj)
	{
		return obj is Percentage other && Equals(other);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}

static class Extensions
{
	public static Percentage Percent(this int value)
	{
		return new Percentage(value / 100.0m);
	}
	
	public static Percentage Percent(this decimal value)
	{
		return new Percentage(value / 100.0m);
	}
}