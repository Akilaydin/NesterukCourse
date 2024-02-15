var game = new Game();
var creature = new Creature(game, "Goblin", 2, 4);
Console.WriteLine(creature.ToString());


using (new DoubleAttackModifier(game, creature))
{
	Console.WriteLine(creature.ToString());
	
	using (new DoubleAttackModifier(game, creature))
	{
		Console.WriteLine(creature.ToString());
		
		using (new DoubleDefenseModifier(game, creature))
		{
			Console.WriteLine(creature.ToString());
		}
	}
}

Console.WriteLine(creature.ToString());

public class Query(string creatureName, QueryArgument argument, int value)
{
	public string CreatureName = creatureName;
	public QueryArgument Argument = argument;
	public int Value = value;
}

public enum QueryArgument
{
	Attack, Defense
}

public class Game
{
	public event EventHandler<Query>? Queries;

	public void PerformQuery(object sender, Query q)
	{
		Queries?.Invoke(sender, q);
	}
}

public class Creature(Game game, string name, int attack, int defense)
{
	public string Name = name;
	
	public int Attack {
		get {
			var query = new Query(Name, QueryArgument.Attack, attack);
			game.PerformQuery(this, query);
			return query.Value;
		}
	}

	public int Defense {
		get {
			var query = new Query(Name, QueryArgument.Defense, defense);
			game.PerformQuery(this, query);
			return query.Value;
		}
	}
	
	public override string ToString()
	{
		return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
	}
}

public abstract class CreatureModifier : IDisposable
{
	private readonly Game _game;
	private readonly Creature _creature;
	
	protected CreatureModifier(Game game, Creature creature)
	{
		_game = game;
		_creature = creature;
		
		game.Queries += HandleQuery;
	}

	public void Dispose()
	{
		_game.Queries -= HandleQuery;
	}

	public abstract void HandleQuery(object? sender, Query query);
}

public class DoubleAttackModifier(Game game, Creature creature) : CreatureModifier(game, creature)
{
	private readonly Creature _creature = creature;

	public override void HandleQuery(object? sender, Query query)
	{
		if (query.CreatureName == _creature.Name && query.Argument == QueryArgument.Attack)
		{
			query.Value *= 2;
		}
	}
}

public class DoubleDefenseModifier(Game game, Creature creature) : CreatureModifier(game, creature)
{
	private readonly Creature _creature = creature;
	
	public override void HandleQuery(object? sender, Query query)
	{
		if (query.CreatureName == _creature.Name && query.Argument == QueryArgument.Defense)
		{
			query.Value *= 2;
		}
	}
}