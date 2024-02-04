using static System.Console;

WriteLine(SingletonDatabase.Instance.GetCityPopulation("Moscow"));

public class SingletonDatabase
{
	public static SingletonDatabase Instance => s_instance.Value;
	
	private static Lazy<SingletonDatabase> s_instance = new();
	
	private Dictionary<string, int> _cities = new ()
	{
		{"Moscow", 5000},
		{"New York", 10000},
		{"Paris", 6700}
	};

	public int GetCityPopulation(string city)
	{
		return _cities[city];
	}
}