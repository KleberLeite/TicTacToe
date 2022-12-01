
using TicTacToe.Core;

Console.WriteLine("Welcome to TicTacToe game! Press any key to play.");
Console.ReadKey();

while (true)
{
    var game = new GameState();
    game.Start();

    try
    {
        Console.Clear();
    }
    catch { }
    Console.WriteLine("Play again (Y/N)?");
    if (!PlayAgain())
        break;
}

bool PlayAgain() => Console.ReadLine().Trim().ToLower() == "y";
