namespace MineSweeper.Domain; 

public class Player
{
    private readonly IBoard _board;

    public int Lives { get; private set; }

    public Square Square { get; private set; }

    public int MoveCount { get; private set; }

    public bool IsAlive => Lives > 0;

    public bool Finished => Square.Rank == 8;

    public Player(IBoard board)
    {
        _board = board;
        Lives = 3;
        MoveCount = 0;
        Square = new Square(0, 0);
    }

    public string Move(string direction)
    {
        var moveMessage = "No Move  ";

        switch (direction)
        {
            case "LeftArrow":
                if (Square.File > 1)
                {
                    moveMessage = "Left  to ";
                    MoveCount++;
                }

                break;

            case "RightArrow":
                if (Square.File < 8)
                {
                    moveMessage = "Right to ";
                    MoveCount++;
                }

                break;

            case "UpArrow":
                if (Square.Rank < 8)
                {
                    moveMessage = "Up    to ";
                    MoveCount++;
                }

                break;

            case "DownArrow":
                if (Square.Rank > 1)
                {
                    moveMessage = "Down  to ";
                    MoveCount++;
                }

                break;
        }

        Square = _board.MakeMove(Square.Name, direction);

        if (Square.IsHidden && Square.IsMine)
        {
            Square.IsHidden = false;

            if (Lives-- == 0)
            {
                return "";
            }
        }
        
        return moveMessage;
    }
}
