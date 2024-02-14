using static System.Console;

var creature = new Creature {
	Agility = {
		Value = 15
	}
};

WriteLine(creature.Agility);

class Creature
{
	public Property<int> Agility { get; } = new();
}

class Property<T>(T value, string name) where T : new()
{
	protected bool Equals(Property<T> other)
	{
		return EqualityComparer<T>.Default.Equals(_value, other._value);
	}
	
	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}
		if (ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != this.GetType())
		{
			return false;
		}
		return Equals((Property<T>)obj);
	}
	
	public override int GetHashCode()
	{
		return EqualityComparer<T>.Default.GetHashCode(_value);
	}
	
	public T Value {
		get => _value;
		set {
			if (Equals(_value, value))
			{
				return;
			}
			WriteLine("Assigning value " + value + " to name " + name);
			_value = value;
		}
	}

	private T _value = value;

	public Property() : this(default, nameof(Property<T>)) { }
	public Property(T value) : this(default, nameof(Property<T>)) { }

	public static implicit operator T(Property<T> p) => p._value;
	public static implicit operator Property<T>(T v) => new(v);
}