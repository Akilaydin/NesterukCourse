var room = new ChatRoom();
var artem = new Person("Artem");
var pasha = new Person("Pasha");

room.JoinRoom(artem);
room.JoinRoom(pasha);

artem.SendPublicMessage("Hey all");
pasha.SendPrivateMessage("Artem", "Hello to you too!");

public class ChatRoom
{
	private List<Person> _chatParticipants = new();

	public void Broadcast(string name, string message)
	{
		foreach (var receiver in _chatParticipants.Where(x => x.Name != name))
		{
			receiver.Receive(name, message);
		}
	}

	public void JoinRoom(Person p)
	{
		string joinMessage = $"{p.Name} joined the chat";
		Broadcast("Room", joinMessage);

		p.Room = this;
		_chatParticipants.Add(p);
	}

	public void SendPrivateMessage(string name, string to, string message)
	{
		_chatParticipants.FirstOrDefault(x => x.Name == to)?.Receive(name, message);
	}
}

public class Person
{
	public string Name;
	public ChatRoom Room;
	private List<string> _chatLog = new List<string>();

	public Person(string name) 
	{
		Name = name;
	}

	public void Receive(string sender, string message)
	{
		string s = $"{sender}: '{message}'";
		Console.WriteLine($"[{Name}'s chat session] {s}");
		_chatLog.Add(s);
	}

	public void SendPublicMessage(string message) => Room.Broadcast(Name, message);

	public void SendPrivateMessage(string to, string message)
	{
		Room.SendPrivateMessage(Name, to, message);
	}
}