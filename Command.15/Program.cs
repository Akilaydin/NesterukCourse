var account1 = new BankAccount(1000);
var account2 = new BankAccount(5000);

var command = new MoneyTransferCommand(account1, account2, 444);

Console.WriteLine(account1.ToString());
Console.WriteLine(account2.ToString());
Console.WriteLine("==================");

Console.WriteLine(command.Do());
Console.WriteLine(account1.ToString());
Console.WriteLine(account2.ToString());
Console.WriteLine("==================");

command.Undo();

Console.WriteLine(account1.ToString());
Console.WriteLine(account2.ToString());
Console.WriteLine("==================");
public class MoneyTransferCommand : CompositeCommand
{
	public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
	{
		AddRange(new [] {
			new BankAccountCommand(from, BankAccountAction.Withdraw, amount),
			new BankAccountCommand(to, BankAccountAction.Deposit, amount)
		});
	}
}

public class CompositeCommand : List<ICommand>, ICommand
{
	public bool Do() => ExecuteCommands(command => command.Do(), true);

	public bool Undo() => ExecuteCommands(command => command.Undo(), false);

	private bool ExecuteCommands(Func<ICommand, bool> operation, bool executeForward)
	{
		var commandStack = new Stack<ICommand>();

		foreach (var command in GetCommands())
		{
			if (operation(command))
			{
				commandStack.Push(command);
			}
			else
			{
				while (commandStack.TryPop(out var doneCommand))
				{
					doneCommand.Undo();
				}

				return false;
			}
		}

		return true;

		IEnumerable<ICommand> GetCommands() => executeForward ? this.AsEnumerable() : this.AsEnumerable().Reverse();
	}
}

public class BankAccount(int balance, int overdraftLimit = 500)
{
	public bool Deposit(int amount)
	{
		balance += amount;
		Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
		return true;
	}

	public bool Withdraw(int amount)
	{
		if (balance - amount >= overdraftLimit)
		{
			balance -= amount;
			Console.WriteLine($"Withdrew ${amount}, balance is now {balance}");
			return true;
		}
		
		return false;
	}
	
	public override string ToString() {
		return $"{nameof(balance)}: {balance}, {nameof(overdraftLimit)}: {overdraftLimit}";
	}
}

public interface ICommand
{ 
	bool Do();

	bool Undo();
}

public class BankAccountCommand(BankAccount account, BankAccountAction action, int amount) : ICommand
{
	public bool Do()
	{
		bool result = false;
		
		switch (action)
		{
			case BankAccountAction.Deposit:
				result = account.Deposit(amount);
				break;
			case BankAccountAction.Withdraw:
				result = account.Withdraw(amount);
				break;
		}

		return result;
	}

	public bool Undo()
	{
		bool result = false;

		switch (action)
		{
			case BankAccountAction.Withdraw:
				result = account.Deposit(amount);
				break;
			case BankAccountAction.Deposit:
				result = account.Withdraw(amount);
				break;
		}
		
		return result;
	}
}

public enum BankAccountAction
{
	Deposit, Withdraw
}