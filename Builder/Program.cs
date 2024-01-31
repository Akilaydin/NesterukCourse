#region
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;

using static System.Console;
#endregion

// Person person = new PersonBuilder().Lives.At("StreetName").In("Moscow").WithPostcode("122220").Works.AsA("Developer").At("Microsoft").Earns(5000);
// WriteLine(person);
var me = Person.New
	.Called("Artem")
	.WorksAsA("Unity developer")
	.Build();

WriteLine(me);

public class Person
{
	public static Builder New => new Builder();
	
	public string Name;

	public string Position;

	public class Builder : PersonJobBuilder<Builder>
	{
		internal Builder() {}
	}
}

public abstract class PersonBuilder
{
	protected Person Person = new Person();

	public Person Build()
	{
		return Person;
	}
}

public class PersonInfoBuilder<TSelf> : PersonBuilder
	where TSelf : PersonInfoBuilder<TSelf>
{
	public TSelf Called(string name)
	{
		Person.Name = name;
		return (TSelf) this;
	}
}

public class PersonJobBuilder<TSelf> 
	: PersonInfoBuilder<TSelf>
	where TSelf : PersonJobBuilder<TSelf>
{
	public TSelf WorksAsA(string position)
	{
		Person.Position = position;
		return (TSelf) this;
	}
}