using static System.Console;

Person person = new PersonBuilder()
	.Lives.At("StreetName").In("Moscow").WithPostcode("122220")
	.Works.AsA("Developer").At("Microsoft").Earns(5000);
WriteLine(person);