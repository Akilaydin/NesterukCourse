ICar car = new CarProxy(new Car(), new Driver { Age = 15 });

car.Drive();

internal interface ICar
{
	void Drive();
}

class Car : ICar
{
	public void Drive()
	{
		Console.WriteLine("Car is driven");
	}
}

class Driver
{
	public required int Age;
}

class CarProxy(Car car, Driver driver) : ICar
{
	public void Drive()
	{
		if (driver.Age <= 16)
		{
			Console.WriteLine("Can't drive");
		}
		else
		{
			car.Drive();
		}
	}
}