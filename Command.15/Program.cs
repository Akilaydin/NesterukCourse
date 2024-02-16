var account = new BankAccount(1000);
var depositCommand = new BankAccountCommand(account, BankAccountAction.Deposit, 500);
var withdrawCommand = new BankAccountCommand(account, BankAccountAction.Withdraw, 500);

depositCommand.Do();
withdrawCommand.Do();

Console.WriteLine(account.ToString());

public class BankAccount(int balance, int overdraftLimit = 500)
{
	public void Deposit(int amount)
	{
		balance += amount;
		Console.WriteLine($"Deposited {amount}. Current balance is {balance}");
	}
	
	public void Withdraw(int amount)
	{
		if (balance + overdraftLimit > amount)
		{
			balance -= amount;
			Console.WriteLine($"Withdraw {amount}. Current balance is {balance}");
		}
		else
		{
			Console.WriteLine("Don't have enough money");
		}
	}
	
	public override string ToString() {
		return $"{nameof(balance)}: {balance}, {nameof(overdraftLimit)}: {overdraftLimit}";
	}
}

public class BankAccountCommand(BankAccount account, BankAccountAction action, int amount)
{
	public void Do()
	{
		switch (action)
		{
			case BankAccountAction.Deposit:
				account.Deposit(amount);
				break;
			case BankAccountAction.Withdraw:
				account.Withdraw(amount);
				break;
		}
	}
}

public enum BankAccountAction
{
	Deposit, Withdraw
}