
var observer = new PersonObserver();
var person = new Person();
var sub = person.Subscribe(observer);
person.CatchACold();
sub.Dispose();
person.CatchACold();


public class PersonObserver : IObserver<EventBase>
{
	public void OnCompleted() { }

	public void OnError(Exception error) { }

	public void OnNext(EventBase value)
	{
		if (value is FallsIllEvent args)
		{
			Console.WriteLine($"Calling a doctor to {args.Address}");
		}
	}
}
public class EventBase
{
	
}

public class FallsIllEvent : EventBase
{
	public string Address;

	public FallsIllEvent(string address) 
	{
		Address = address;
	}
}

public class Person : IObservable<EventBase>
{
	private readonly HashSet<Subscription> _subscriptions = new();

	public void CatchACold()
	{
		foreach (var subscription in _subscriptions)
		{
			subscription.Observer.OnNext(new FallsIllEvent("Moscow"));
		}
	}

	public IDisposable Subscribe(IObserver<EventBase> observer)
	{
		var subscription = new Subscription(this, observer);

		_subscriptions.Add(subscription);

		return subscription;
	}

	private class Subscription(Person person, IObserver<EventBase> observer) : IDisposable
	{
		public IObserver<EventBase> Observer { get; } = observer;
		
		public void Dispose()
		{
			person._subscriptions.Remove(this);
		}
	}
}
