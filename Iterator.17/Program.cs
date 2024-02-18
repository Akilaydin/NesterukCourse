var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));

var tree = new BinaryTree<int>(root);

foreach (var node in tree)
{
	Console.WriteLine(node.Value);
}

Console.WriteLine(string.Join(",", tree.InOrder.Select(x => x.Value)));

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

public class BinaryTree<T>
{
	public IEnumerable<Node<T>> InOrder
	{
		get
		{
			IEnumerable<Node<T>> TraverseInOrder(Node<T> current)
			{
				if (current.Left != null)
				{
					foreach (var left in TraverseInOrder(current.Left))
						yield return left;
				}
				yield return current;
				if (current.Right != null)
				{
					foreach (var right in TraverseInOrder(current.Right))
						yield return right;
				}
			}
			foreach (var node in TraverseInOrder(_root))
				yield return node;
		}
	}

	public InOrderIterator<T> GetEnumerator()
	{
		return new InOrderIterator<T>(_root);
	}

	private Node<T> _root;

	public BinaryTree(Node<T> root) 
	{
		_root = root;
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
