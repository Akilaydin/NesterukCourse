public class PersonJobBuilder(Person person) : PersonBuilder(person)
{
	public PersonJobBuilder At(string companyName)
	{
		Person.CompanyName = companyName;
		return this;
	}

	public PersonJobBuilder AsA(string position)
	{
		Person.Position = position;
		return this;
	}

	public PersonJobBuilder Earns(int annualIncome)
	{
		Person.AnnualIncome = annualIncome;
		return this;
	}
}