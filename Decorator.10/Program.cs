using static System.Console;

public interface ICreature
{
	public int Age { get; set; }
}

public interface IFlyable : ICreature
{
	void Fly();
}
public class Bird : IFlyable
{
	public int Age { get; set; }
	public void Fly()
	{
		if (Age >= 10)
		{
			WriteLine("I am flying!");
		}
	}
}

public interface ICrawlable : ICreature
{
	void Crawl();
}
public class Lizard : ICrawlable
{
	public int Age { get; set; }
	public void Crawl()
	{
		if (Age < 10)
		{
			WriteLine("I am crawling!");
		}
	}
}

public class Dragon : IFlyable, ICrawlable
{
	public required IFlyable Flyable;
	public required ICrawlable Crawlable;

	public int Age 
	{
		get => Flyable.Age;
		set => Flyable.Age = Crawlable.Age = value;
	}

	public void FireBreath()
	{
		Console.WriteLine("Breating fire");
	}

	public void Crawl() => Crawlable.Crawl();

	public void Fly() => Flyable.Fly();
}
