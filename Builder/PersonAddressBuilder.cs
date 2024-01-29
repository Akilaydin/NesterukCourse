public class PersonAddressBuilder(Person person) : PersonBuilder(person)
{
	public PersonAddressBuilder At(string streetAddress)
	{
		Person.StreetAddress = streetAddress;
		return this;
	}
  
	public PersonAddressBuilder WithPostcode(string postcode)
	{
		Person.Postcode = postcode;
		return this;
	}
  
	public PersonAddressBuilder In(string city)
	{
		Person.City = city;
		return this;
	}
}