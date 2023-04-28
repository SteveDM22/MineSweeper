using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Domain;

public class Board : IBoard
{
    internal readonly IList<Square> Squares = new List<Square>();

    public Board()
    { 
        for (var file = 1; file < 9; file++)
        {
            for (var rank = 1; rank < 9; rank++)
            {
                Squares.Add(new Square(file, rank));
            }
        }
    }

    public Square MakeMove(string name, string direction)
    {
        var file = name[0] - 64;
        var rank = int.Parse(name[1].ToString());

        return MakeMove(file, rank, direction);
    }

    private Square MakeMove(int file, int rank, string direction)
    {
        var currentSquare = Squares.SingleOrDefault(c => c.File == file && c.Rank == rank);
        currentSquare ??= new Square(file, rank);
        
        switch (direction)
        {
            case "LeftArrow":
                if (currentSquare.File > 1)
                {
                    currentSquare = Squares.Single(c => c.File == file - 1 && c.Rank == rank);
                }

                break;

            case "RightArrow":
                if (currentSquare.File < 8)
                {
                    currentSquare = Squares.Single(c=> c.File == file + 1 && c.Rank == rank);
                }

                break;

            case "UpArrow":
                if (currentSquare.Rank < 8)
                {
                    currentSquare = Squares.Single(c => c.File == file && c.Rank == rank + 1);
                }

                break;

            case "DownArrow":
                if (currentSquare.Rank > 1)
                {
                    currentSquare = Squares.Single(c => c.File == file && c.Rank == rank - 1);
                }

                break;
        }

        return currentSquare;
    }

    public void SetMine(string cellName)
    {
        Squares.Single(c => c.Name == cellName).IsMine = true;
    }
}
