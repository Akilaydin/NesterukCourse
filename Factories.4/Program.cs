#region
#endregion


var factory = new PersonFactory();
var artem = factory.CreatePerson("Artem");
var andrew = factory.CreatePerson("Andrew");

Console.WriteLine($"{artem} {andrew}");

public class PersonFactory
{
	private static int s_id;
	
	public Person CreatePerson(string name)
	{
		s_id++;
		return new Person(s_id, name);
	}
}
public record Person (int Id, string Name);