var person = new Person();

void OnPersonOnFallsIll(object? sender, FallsIllEventArgs eventArgs)
{
	Console.WriteLine($"Calling a doctor to {eventArgs.Address}");
}

person.FallsIll += OnPersonOnFallsIll;
person.FallsIll += OnPersonOnFallsIll;

person.FallIll();

person.FallsIll -= OnPersonOnFallsIll;

person.FallIll();

public class FallsIllEventArgs : EventArgs
{
	public required string Address;
}

public class Person
{
	public event EventHandler<FallsIllEventArgs> FallsIll;

	public void FallIll()
	{
		FallsIll?.Invoke(this, new FallsIllEventArgs {Address = "Moscow"});
	}
}