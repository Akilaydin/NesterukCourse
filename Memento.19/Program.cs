using static System.Console;

var bankAccount = new BankAccount(100);
bankAccount.Deposit(50);
bankAccount.Deposit(25);
WriteLine(bankAccount);

bankAccount.Undo();
WriteLine($"Undo 1: {bankAccount}");
bankAccount.Undo();
WriteLine($"Undo 2: {bankAccount}");
bankAccount.Redo();
bankAccount.Redo();
bankAccount.Redo();
WriteLine($"Redo 2: {bankAccount}");

public class Memento(int balance)
{
	public int Balance { get; } = balance;
}

public class BankAccount
{
	private List<Memento> _changes = new();
	private int _currentChangeIndex;
	private int _balance;

	public BankAccount(int balance)
	{
		_balance = balance;
		_changes.Add(new Memento(balance));
	}

	public Memento Deposit(int amount)
	{
		_balance += amount;
		
		var memento = new Memento(_balance);
		
		_changes.Add(memento);
		
		_currentChangeIndex++;
		
		return memento;
	}

	public void Restore(Memento? memento)
	{
		if (memento != null)
		{
			_balance = memento.Balance;
			
			_changes.Add(memento);

			_currentChangeIndex = _changes.Count - 1;
		}
	}

	public Memento? Redo()
	{
		if (_currentChangeIndex + 1 < _changes.Count)
		{
			var memento = _changes[++_currentChangeIndex];
			
			_balance = memento.Balance;
			
			return memento;
		}
		
		return null;
	}
	
	public Memento? Undo()
	{
		if (_currentChangeIndex > 0)
		{
			var memento = _changes[--_currentChangeIndex];
			_balance = memento.Balance;
			return memento;
		}
		
		return null;
	}
	
	public override string ToString()
	{
		return $"{nameof(_balance)}: {_balance}";
	}
}
