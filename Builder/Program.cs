#region
using static System.Console;
#endregion

// Person person = new PersonBuilder().Lives.At("StreetName").In("Moscow").WithPostcode("122220").Works.AsA("Developer").At("Microsoft").Earns(5000);
// WriteLine(person);

var builder = new PersonBuilder();
var person = builder.Called("Artem").WorksAsA("Unity developer").Build();
WriteLine(person.Name);

public class Person
{
	public string Name, Position;
}

public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>;

public static class PersonBuilderExtensions
{
	public static PersonBuilder Called(this PersonBuilder builder, string name)
	{
		builder.AddAction(person => person.Name = name);

		return builder;
	}
	public static PersonBuilder WorksAsA(this PersonBuilder builder, string position)
	{
		builder.AddAction(person => person.Position = position);

		return builder;
	}
}

public abstract class FunctionalBuilder<TSubject, TSelf> 
	where TSelf : FunctionalBuilder<TSubject, TSelf>
	where TSubject : new()
{
	private readonly List<Func<TSubject, TSubject>> _buildActions = new();
	
	public TSubject Build() => _buildActions.Aggregate(new TSubject(), (subject, buildAction) => buildAction(subject));
	
	public TSelf AddAction(Action<TSubject> action)
	{
		_buildActions.Add(subject =>
		{
			action(subject);
			return subject;
		});

		return (TSelf)this;
	}
}