#region
using static System.Console;
#endregion

var log = new ConsoleLog();
var ba = new BankAccount(log);
ba.Deposit(100);
ba.Withdraw(200);

public interface ILog
{
	void Info(string msg);

	void Warn(string msg);
}

internal class ConsoleLog : ILog
{
	public void Info(string msg)
	{
		WriteLine(msg);
	}

	public void Warn(string msg)
	{
		WriteLine("WARNING: " + msg);
	}
}

internal class OptionalLog(ILog impl) : ILog
{
	public void Info(string msg)
	{
		impl?.Info(msg);
	}

	public void Warn(string msg)
	{
		impl?.Warn(msg);
	}
}

public class BankAccount(ILog log)
{
	private ILog _log = new OptionalLog(log);
	private int _balance;

	public void Deposit(int amount)
	{
		_balance += amount;
		// check for null everywhere
		_log?.Info($"Deposited ${amount}, balance is now {_balance}");
	}

	public void Withdraw(int amount)
	{
		if (_balance >= amount)
		{
			_balance -= amount;
			_log?.Info($"Withdrew ${amount}, we have ${_balance} left");
		}
		else
		{
			_log?.Warn($"Could not withdraw ${amount} because " + $"balance is only ${_balance}");
		}
	}
}

public sealed class NullLog : ILog
{
	public void Info(string msg) { }

	public void Warn(string msg) { }
}
