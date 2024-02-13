var subsystemA = new SubsystemClassA();
var subsystemB = new SubsystemClassB();
var subsystemC = new SubsystemClassC();
var facade = new Facade(subsystemA, subsystemB, subsystemC);

facade.FacadeOperation(); //Client gets facade for example from DI. Client does not create facade himself

public class SubsystemClassA
{
	public void OperationA() => Console.WriteLine("SubsystemClassA OperationA");
}

public class SubsystemClassB
{
	public void OperationB() => Console.WriteLine("SubsystemClassB OperationB");
}

public class SubsystemClassC
{
	public void OperationC() => Console.WriteLine("SubsystemClassC OperationC");
}

public class Facade(SubsystemClassA subsystemA, SubsystemClassB subsystemB, SubsystemClassC subsystemC)
{
	private SubsystemClassA _subsystemA = subsystemA ?? throw new ArgumentNullException(nameof(subsystemA));
	private SubsystemClassB _subsystemB = subsystemB ?? throw new ArgumentNullException(nameof(subsystemB));
	private SubsystemClassC _subsystemC = subsystemC ?? throw new ArgumentNullException(nameof(subsystemC));

	//Client doesn't need to know about subsystems
	public void FacadeOperation()
	{
		Console.WriteLine("Facade initializes subsystems:");
		_subsystemA.OperationA();
		_subsystemB.OperationB();
		_subsystemC.OperationC();
		Console.WriteLine("Operation completed.");
	}
}
