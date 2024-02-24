var rules = new Dictionary<State, List<(Trigger, State)>> {
	[State.OffHook] = [(Trigger.CallDialed, State.Connecting)],
	[State.Connecting] = [
		(Trigger.HungUp, State.OnHook),
		(Trigger.CallConnected, State.Connected)
	],
	[State.Connected] = [
		(Trigger.LeftMessage, State.OnHook),
		(Trigger.HungUp, State.OnHook),
		(Trigger.PlacedOnHold, State.OnHold)
	],
	[State.OnHold] = [
		(Trigger.TakenOffHold, State.Connected),
		(Trigger.HungUp, State.OnHook)
	]
};

State 
	state = State.OffHook, 
	exitState = State.OnHook;

var queue = new Queue<int>(new[]{0, 1, 2, 0, 0});

do
{
	Console.WriteLine($"The phone is currently {state}");
	Console.WriteLine("Select a trigger:");

	for (var i = 0; i < rules[state].Count; i++)
	{
		var (t, _) = rules[state][i];
		Console.WriteLine($"{i}. {t}");
	}

	int input = int.Parse(Console.ReadLine());
	Console.WriteLine($"Chosen {input}");

	var (_, s) = rules[state][input];
	state = s;
} 
while (state != exitState);

Console.WriteLine("We are done using the phone.");

public enum State
 {
	 OffHook,
	 Connecting,
	 Connected,
	 OnHold,
	 OnHook
 }

 public enum Trigger
 {
	 CallDialed,
	 HungUp,
	 CallConnected,
	 PlacedOnHold,
	 TakenOffHold,
	 LeftMessage
 }