var people = new List<Person>();

people.Sort();
people.Sort((x,y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
people.Sort(Person.nameComparer);

public class Person : IEquatable<Person>, IComparable<Person>, IComparable
{
	private sealed class NameRelationalComparer : IComparer<Person>
	{
		public int Compare(Person x, Person y)
		{
			if (ReferenceEquals(x, y))
			{
				return 0;
			}
			if (ReferenceEquals(null, y))
			{
				return 1;
			}
			if (ReferenceEquals(null, x))
			{
				return -1;
			}
			return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
		}
	}
	public static IComparer<Person> nameComparer { get; } = new NameRelationalComparer();
	private sealed class NameEqualityComparer : IEqualityComparer<Person>
	{
		public bool Equals(Person x, Person y)
		{
			if (ReferenceEquals(x, y))
			{
				return true;
			}
			if (ReferenceEquals(x, null))
			{
				return false;
			}
			if (ReferenceEquals(y, null))
			{
				return false;
			}
			if (x.GetType() != y.GetType())
			{
				return false;
			}
			return x.Name == y.Name;
		}
		public int GetHashCode(Person obj)
		{
			return obj.Name.GetHashCode();
		}
	}
	public static IEqualityComparer<Person> nameEqualityComparer { get; } = new NameEqualityComparer();
	public int CompareTo(Person? other)
	{
		if (ReferenceEquals(this, other))
		{
			return 0;
		}
		if (ReferenceEquals(null, other))
		{
			return 1;
		}
		var idComparison = Id.CompareTo(other.Id);
		if (idComparison != 0)
		{
			return idComparison;
		}
		var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
		if (nameComparison != 0)
		{
			return nameComparison;
		}
		return Age.CompareTo(other.Age);
	}
	public int CompareTo(object? obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return 1;
		}
		if (ReferenceEquals(this, obj))
		{
			return 0;
		}
		return obj is Person other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Person)}");
	}
	public static bool operator <(Person? left, Person? right)
	{
		return Comparer<Person>.Default.Compare(left, right) < 0;
	}
	public static bool operator >(Person? left, Person? right)
	{
		return Comparer<Person>.Default.Compare(left, right) > 0;
	}
	public static bool operator <=(Person? left, Person? right)
	{
		return Comparer<Person>.Default.Compare(left, right) <= 0;
	}
	public static bool operator >=(Person? left, Person? right)
	{
		return Comparer<Person>.Default.Compare(left, right) >= 0;
	}
	public bool Equals(Person? other)
	{
		if (ReferenceEquals(null, other))
		{
			return false;
		}
		if (ReferenceEquals(this, other))
		{
			return true;
		}
		return Id == other.Id;
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
		return Equals((Person)obj);
	}
	public override int GetHashCode()
	{
		return Id;
	}
	public static bool operator ==(Person? left, Person? right) {
		return Equals(left, right);
	}
	public static bool operator !=(Person? left, Person? right) {
		return !Equals(left, right);
	}
	public int Id { get; set; }
	public string Name { get; set; }
	public int Age { get; set; }
}