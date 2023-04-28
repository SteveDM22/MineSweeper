namespace MineSweeper.Domain;

public interface IBoard
{
    void SetMine(string cellName);

    Square MakeMove(string name, string direction);
}
