
using TicTacToe.Core.Extensions;

namespace TicTacToe.Core;
public class GameState
{
    private Player currentPlayer;
    private Player nextPlayer;

    private Board board;

    public GameState()
    {
        var randomAssign = (PlayerAssign)(Random.Shared.Next(1, 3));
        currentPlayer = new Player(randomAssign);
        nextPlayer = new Player(randomAssign.GetNext());

        board = new();
    }

    public void Start()
    {
        for (int round = 1; round <= 9; round++)
        {
            var tile = GetTileToPlay();
            tile.TryAssign(currentPlayer.Assign);

            if (round >= 5 && PlayWins(tile.GridPosition)) // 5 is the minimum number of rounds to have a winner
            {
                try
                {
                    Console.Clear();
                }
                catch { }

                Console.WriteLine(board.GetDrawBoard());
                Console.WriteLine($"{currentPlayer.Name} wins! Pressy any key to continue.");
                Console.ReadKey();
                return;
            }
            ChangePlayers();
        }

        try
        {
            Console.Clear();
        }
        catch { }

        Console.WriteLine(board.GetDrawBoard());
        Console.WriteLine($"Draw game! Pressy any key to continue.");
        Console.ReadKey();
    }

    private Tile GetTileToPlay()
    {
        int targetTileId = 0;
        string drawBoard = board.GetDrawBoard();
        while (true)
        {
            try
            {
                Console.Clear();
            }
            catch { }

            Console.WriteLine(drawBoard);
            Console.WriteLine($"{currentPlayer.Name} insert your play!");

            if (int.TryParse(Console.ReadLine(), out targetTileId))
            {
                var tile = board[targetTileId];
                if (tile != null && !tile.Assigned)
                    return tile;
            }
        }
    }

    private bool PlayWins(Vector2Int tilePos)
    {
        if (!Enumerable.Range(0, 3).Select(x => board[x, tilePos.y]).Any(t => t.Assign != currentPlayer.Assign))
            return true;

        if (!Enumerable.Range(0, 3).Select(y => board[tilePos.x, y]).Any(t => t.Assign != currentPlayer.Assign))
            return true;

        if (!Enumerable.Range(0, 3).Select(i => board[7 - 2 * i]).Any(t => t.Assign != currentPlayer.Assign))
            return true;

        if (!Enumerable.Range(0, 3).Select(i => board[1 + 4 * i]).Any(t => t.Assign != currentPlayer.Assign))
            return true;

        return false;
    }

    private void ChangePlayers()
    {
        var currentPlayerSnapshot = currentPlayer;
        currentPlayer = nextPlayer;
        nextPlayer = currentPlayerSnapshot;
    }

    private class Player
    {
        public readonly string Name;
        public readonly PlayerAssign Assign;

        public Player(PlayerAssign assign)
        {
            Assign = assign;
            Name = assign.ToString();
        }
    }
}
