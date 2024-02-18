var game = new Game();
var player = new Player("Artem", game);
var coach = new Coach(game);

player.Score();
player.Score();
player.Score();
player.Score();
player.Score();

public abstract class GameEventArgs : EventArgs
{
	public abstract void Print();
}

public class PlayerScoredEventArgs(string playerName, int goalsScoredSoFar) : GameEventArgs
{
	public readonly string PlayerName = playerName;
	public readonly int GoalsScoredSoFar = goalsScoredSoFar;

	public override void Print()
	{
		Console.WriteLine($"{PlayerName} scored {GoalsScoredSoFar} goals so far");
	}
}

public class Game
{
	public event EventHandler<GameEventArgs> Events;

	public void Fire(GameEventArgs args)
	{
		Events?.Invoke(this, args);
	}
}

public class Player(string name, Game game)
{
	private int _goalsScored;

	public void Score()
	{
		_goalsScored++;
		var args = new PlayerScoredEventArgs(playerName: name, _goalsScored);
		game.Fire(args);
	}
}

public class Coach
{
	private Game _game;

	public Coach(Game game) 
	{
		_game = game;

		_game.Events += (_, args) =>
		{
			args.Print();
			
			if (args is PlayerScoredEventArgs { GoalsScoredSoFar: > 3 } scoredEventArgs)
			{
				Console.WriteLine($"Coach says: well done, {scoredEventArgs.PlayerName}!");
			}
		};
	}
}