public class PersonBuilder
{
	public PersonAddressBuilder Lives => new(Person);
	public PersonJobBuilder Works => new(Person);
	
	protected Person Person;

	public PersonBuilder()
	{
		Person = new Person();
	}

	protected PersonBuilder(Person person)
	{
		Person = person;
	}
	
	public static implicit operator Person(PersonBuilder pb)
	{
		return pb.Person;
	}
}