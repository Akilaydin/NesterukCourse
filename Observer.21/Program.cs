using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Person : INotifyPropertyChanged, INotifyPropertyChanging
{
	private int _age;
	public int Age {
		get => _age;
		set {
			if (value == _age)
			{
				return;
			}
			OnPropertyChanging(); //will fill property name parameter with "Age"
			_age = value;
			OnPropertyChanged(nameof(Age)); //also will fill property name parameter with "Age"
		}
	}
	public event PropertyChangedEventHandler? PropertyChanged;
	public event PropertyChangingEventHandler? PropertyChanging;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	
	protected virtual void OnPropertyChanging([CallerMemberName] string? propertyName = null)
	{
		PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
	}
	
	protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
		{
			return false;
		}
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}
}