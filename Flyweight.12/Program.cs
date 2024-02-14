var user = new User("Artem Ovchinnikov");
var user2 = new User("Eugeni Ovchinnikov");
var user3 = new User("user Ovchinnikov");
var user4 = new User("user2 Ovchinnikov");

Console.WriteLine(User.s_strings.Count); //outputs 3 because Ovchinnikov didn't allocate twice

public class User
{
	public string FullName => string.Join(" ", _names.Select(index => s_strings[index])); //cache
	
	public static List<string> s_strings = new();
	
	private int[] _names;

	public User(string fullName)
	{
		_names = fullName.Split(' ').Select(GetOrAdd).ToArray();
	}

	private int GetOrAdd(string s)
	{
		var index = s_strings.IndexOf(s);
		
		if (index != -1)
		{
			return index;
		}
		
		s_strings.Add(s);
		
		return s_strings.Count - 1;
	}
}