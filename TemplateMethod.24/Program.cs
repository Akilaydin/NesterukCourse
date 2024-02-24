using static System.Console;

const int numberOfPlayers = 2;
const int maxTurns = 10;
int currentPlayer = 0;
int turn = 1;

GameTemplate.Run(Start, TakeTurn, HaveWinner, WinningPlayer);
return;

void Start() => WriteLine($"Starting a game of chess with {numberOfPlayers} players.");

void TakeTurn()
{
	WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
	currentPlayer = (currentPlayer + 1) % numberOfPlayers;
}

bool HaveWinner() => turn == maxTurns;

int WinningPlayer() => currentPlayer;

public static class GameTemplate
{
	public static void Run(
		Action start,
		Action takeTurn,
		Func<bool> haveWinner,
		Func<int> winningPlayer)
	{
		start();
		while (!haveWinner())
		{
			takeTurn();
		}
		
		WriteLine($"Player {winningPlayer()} wins.");
	}
}
