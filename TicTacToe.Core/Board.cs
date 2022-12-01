
using TicTacToe.Core.Extensions;

namespace TicTacToe.Core;
public class Board
{
    private Tile[,] grid;

    public Board()
    {
        grid = new Tile[3, 3];
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                grid[x, y] = new Tile(new Vector2Int(x, y));
    }

    public Tile this[int id]
    {
        get
        {
            if (id > 9 || id < 1)
                return null;

            int x = (id - 1) % 3;
            int y = (id - x - 1) / 3;
            return grid[x, y];
        }
    }

    public Tile this[int x, int y]
    {
        get
        {
            if (x > 2 || x < 0 || y > 2 || y < 0)
                return null;

            return grid[x, y];
        }
    }

    public string GetDrawBoard()
    {
        // DrawingBoard Model:
        //     7   |   8   |   9   
        //  -----------------------
        //     4   |   5   |   6   
        //  -----------------------
        //     1   |   2   |   3    

        string horizontalBar = "-----------------------";
        string[] lines = new string[5];

        int yLine = 2;
        for (int y = 4; y >= 0; y--) // 5 vertical steps
        {
            if (y % 2 == 0)
            {
                lines[y] = GetLineDrawBoard(yLine);
                yLine--;
            }
            else
                lines[y] = horizontalBar;
        }

        return string.Join("\n", lines);
    }

    private string GetLineDrawBoard(int y)
    {
        string[] values = new string[3];
        for (int x = 0; x < 3; x++)
        {
            if (!grid[x, y].Assigned)
                values[x] = $"   {(x + 1) + (3 * y)}   {(x != 2 ? "|" : "")}";
            else
                values[x] = $"   {grid[x, y].Assign.GetAssign()}   {(x != 2 ? "|" : "")}";
        }

        return String.Concat(values);
    }
}
