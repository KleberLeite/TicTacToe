
namespace TicTacToe.Core.Extensions;
public static class PlayerAssignExtensions
{
    public static PlayerAssign GetNext(this PlayerAssign assign)
    {
        if (assign == PlayerAssign.None)
        {
            Console.WriteLine("Error: GetNext of PlayerAssign.None");
            Console.ReadLine();
            return PlayerAssign.None;
        }

        return assign == PlayerAssign.PlayerOne ? PlayerAssign.PlayerTwo : PlayerAssign.PlayerOne;
    }

    public static string GetAssign(this PlayerAssign assign)
    {
        if (assign == PlayerAssign.None)
        {
            Console.WriteLine("Error: GetAssign of PlayerAssign.None");
            Console.ReadLine();
            return "";
        }

        return assign == PlayerAssign.PlayerOne ? "X" : "O";
    }
}
