var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
var iterator = new InOrderIterator<int>(root);

while (iterator.MoveNext())
{
	Console.Write(iterator.Current.Value);
	Console.Write(',');
}

public class Node<T>
{
	public readonly T? Value;
	public readonly Node<T>? Left, Right;
	public Node<T>? Parent;

	public Node(T value)
	{
		Value = value;
	}

	public Node(T value, Node<T> left, Node<T> right)
	{
		Value = value;
		Left = left;
		Right = right;

		left.Parent = right.Parent = this;
	}
}

public class InOrderIterator<T>
{
	public Node<T> Current { get; private set; }
	private readonly Node<T> _root;
	private bool _yieldedStart;

	public InOrderIterator(Node<T> root)
	{
		_root = Current = root;

		while (Current.Left != null)
		{
			Current = Current.Left;
		}
	}

	public bool MoveNext()
	{
		if (!_yieldedStart)
		{
			_yieldedStart = true;
			return true;
		}

		if (Current.Right != null)
		{
			Current = Current.Right;
			while (Current.Left != null)
			{
				Current = Current.Left;
			}
			return true;
		}
		var p = Current.Parent;
		while (p != null && Current == p.Right)
		{
			Current = p;
			p = p.Parent;
		}
		Current = p;
		return Current != null;
	}
}
