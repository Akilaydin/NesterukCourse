using System.Collections;

// var creatures = new BadCreature[100];
//
// foreach (var c in creatures)
// {
// 	c.X++; // not memory-efficient
// }

var creatures2 = new Creatures(100);

foreach (var c in creatures2)
{
	c.X++;
	Console.Write(c.X);
}

public class Creatures(int size) : IEnumerable<Creatures.Creature>
{
	private byte[] _ages = new byte [size];
	private int[] _x = new int[size];
	private int[] _y = new int[size];
	
	public struct Creature(Creatures creatures, int index)
	{
		public ref byte Age => ref creatures._ages[index];
		public ref int X => ref creatures._x[index];
		public ref int Y => ref creatures._y[index];
	}

	public IEnumerator<Creature> GetEnumerator()
	{
		for (int pos = 0; pos < size; ++pos)
		{
			yield return new Creature(this, pos);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

public class BadCreature
{
	public byte Age;
	public int X, Y;
}
