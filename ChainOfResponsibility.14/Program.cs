var creature = new Creature("Goblin", 2, 4);

var root = new CreatureModifier(creature);
root.AddModifier(new DoubleAttackModifier(creature));
root.AddModifier(new DoubleAttackModifier(creature));
root.AddModifier(new DoubleAttackModifier(creature));
root.AddModifier(new RemoveAllModifiersModifier(creature));
root.AddModifier(new DoubleAttackModifier(creature));
root.AddModifier(new DoubleAttackModifier(creature));
root.AddModifier(new DoubleAttackModifier(creature));

root.AddModifier(new DoubleDefenseModifier(creature));
root.AddModifier(new DoubleDefenseModifier(creature));
root.AddModifier(new DoubleDefenseModifier(creature));
root.AddModifier(new DoubleDefenseModifier(creature));
root.AddModifier(new DoubleDefenseModifier(creature));

root.Handle();

Console.WriteLine(creature.ToString());

public class Creature(string name, int attack, int defense)
{
	public string Name = name;
	public int Attack = attack, Defense = defense;

	public override string ToString()
	{
		return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
	}
}

public class CreatureModifier(Creature creature)
{
	protected readonly Creature Creature = creature;
	private CreatureModifier? _next;
	
	public virtual void Handle() => _next?.Handle();

	public void AddModifier(CreatureModifier cm)
	{
		if (_next != null)
		{
			_next.AddModifier(cm);
		}
		else
		{
			_next = cm;
		}
	}
}

public class RemoveAllModifiersModifier(Creature creature) : CreatureModifier(creature) 
{
	//note: absence of base.Handle() so we interrupt the chain
	public override void Handle()
	{
		Console.WriteLine("No modifiers further on");
	}
}

public class RemoveDefenseModifier(Creature creature) : CreatureModifier(creature) 
{
	public override void Handle()
	{
		Console.WriteLine("Removing the defense");
		
		Creature.Defense = 0;

		base.Handle();
	}
}

public class DoubleAttackModifier(Creature creature) : CreatureModifier(creature) 
{
	public override void Handle()
	{
		Console.WriteLine("Doubling the attack");
		
		Creature.Attack *= 2;
		
		base.Handle();
	}
}

public class DoubleDefenseModifier(Creature creature) : CreatureModifier(creature) 
{
	public override void Handle()
	{
		Console.WriteLine("Doubling the defense");
		
		Creature.Defense *= 2;
		
		base.Handle();
	}
}