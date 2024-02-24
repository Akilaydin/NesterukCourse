using static System.Console;

Game game = new Chess();
game.Run();

public abstract class Game(int numberOfPlayers)
{
	public void Run()
	{
		Start();
		while (!HaveWinner)
		{
			TakeTurn();
		}
		
		WriteLine($"Player {WinningPlayer} wins.");
	}

	protected abstract void Start();
	protected abstract bool HaveWinner { get; }
	protected abstract void TakeTurn();
	protected abstract int WinningPlayer { get; }

	protected int CurrentPlayer;

	protected readonly int NumberOfPlayers = numberOfPlayers;
}

public class Chess() : Game(2)
{
	protected override void Start()
	{
		WriteLine($"Starting a game of chess with {NumberOfPlayers} players.");
	}

	protected override bool HaveWinner => _turn == s_maxTurns;

	protected override void TakeTurn()
	{
		WriteLine($"Turn {_turn++} taken by player {CurrentPlayer}.");
		CurrentPlayer = (CurrentPlayer + 1) % NumberOfPlayers;
	}

	protected override int WinningPlayer => CurrentPlayer;

	private const int s_maxTurns = 10;
	private int _turn = 1;
}
