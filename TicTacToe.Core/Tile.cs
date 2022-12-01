
namespace TicTacToe.Core;
public class Tile
{
    public Vector2Int GridPosition;

    public PlayerAssign Assign { get; private set; }
    public bool Assigned => Assign != PlayerAssign.None;

    public Tile(Vector2Int gridPosition) => GridPosition = gridPosition;

    public void TryAssign(PlayerAssign player)
    {
        if (player == PlayerAssign.None)
        {
            Console.WriteLine("Error: TryAssign tile with TilePlayer.None");
            Console.ReadLine();
            return;
        }
        else if (Assigned)
        {
            Console.WriteLine("Error: TryAssign assigned tile");
            Console.ReadLine();
            return;
        }

        Assign = player;
    }
}
