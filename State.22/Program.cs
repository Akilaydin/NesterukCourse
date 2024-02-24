using System.Text;

const string code = "1234";

var currentState = LockState.Locked;
var input = new StringBuilder();
var mockInputData = new Queue<int>(new[] { 1, 2, 2, 4 });

while (true)
{
	switch (currentState)
	{
		case LockState.Locked:
			var inputValue = mockInputData.Dequeue();
			Console.WriteLine($"Input: {inputValue}");
			input.Append(inputValue);
			
			if (input.ToString() == code)
			{
				currentState = LockState.Unlocked;
			}

			if (!code.StartsWith(input.ToString()))
			{
				currentState = LockState.FailedToUnlock;
			}
			
			break;
			
		case LockState.FailedToUnlock:
			Console.WriteLine("Failed to unlock =(");
			return;
		case LockState.Unlocked:
			Console.WriteLine("Unlocked!");
			return;
	}
}

public enum LockState
{
	Locked,
	FailedToUnlock,
	Unlocked
}