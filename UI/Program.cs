using MineSweeper.Domain;
using static System.Console;

namespace MineSweeper.UI;

public class Program
{
    private readonly Board _board = new();

    public static void Main()
    {
        new Program().Run();
    }

    private void Run()
    {
        SetUpDisplay();
        SetupBoard();
        var player = new Player(_board);
        GetStartingRank(player);
        WriteLine($"> Start at {player.Square.Name}. {player.MoveCount} Moves taken. {player.Lives} lives remaining.");

        while (player is { IsAlive: true, Finished: false })
        {
            Write("> ");
            var moveMessage = player.Move(ReadKey(true).Key.ToString());
            WriteLine($"{moveMessage}{player.Square.Name}. {player.MoveCount} Moves taken. {player.Lives} lives remaining.");
        }

        Exit(!player.IsAlive ? "You Loose." : "You Win.");
    }

    private static void SetUpDisplay()
    {
        Clear();
        WriteLine("");
        WriteLine("===============================================================================");
        WriteLine("          * * * ** ** ** *** *** Mine Sweeper *** *** ** ** ** * * *");
        WriteLine("===============================================================================");
        WriteLine("");
        WriteLine("1) You start at Rank 1 of the Chessboard but are free to choose the starting ");
        WriteLine("   File [A..H].");
        WriteLine("2) Move by using the cursor keys.");
        WriteLine("3) Hit a mine you loose a life. Loose three lives and you loose the game.");
        WriteLine("4) When you hit a mine it is removed from the board.");
        WriteLine("5) Get to Rank 8 without loosing all your lives and you are a WINNER!");
        WriteLine("");
        WriteLine("===============================================================================");
        WriteLine("[HINT: Avoid the positive diagonal!]");
        WriteLine("");
    }

    private void SetupBoard()
    {
        _board.SetMine("A1");
        _board.SetMine("B2");
        _board.SetMine("C3");
        _board.SetMine("D4");
        _board.SetMine("E5");
        _board.SetMine("F6");
        _board.SetMine("G7");
        _board.SetMine("H8");
    }

    private static void GetStartingRank(Player player)
    {
        Write("Which File would you like to start at [A, B, C, D, E, F, G or H]? ");

        while (true)
        {
            var fileKey = ReadKey(true);
            var file = (int)fileKey.Key - 64;

            if (file > 0 && file < 9)
            {
                player.Square.File = file;
                player.Move("UpArrow");
                WriteLine(fileKey.KeyChar);
                WriteLine("");

                break;
            }
        }
    }

    private static void Exit(string message)
    {
        WriteLine("");
        WriteLine(message);
        WriteLine("");
        Write("Press any key to exit.");
        ReadKey(true);
    }
}