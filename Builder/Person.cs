public class Person
{
	public string StreetAddress, Postcode, City;
	public string CompanyName, Position;
	public int AnnualIncome;
	
	public Person()
	{
		Console.WriteLine("Creating an instance of Person");
	}
	
	public override string ToString()
	{
		return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}," +
			$" {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}," +
			$" {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
	}
}