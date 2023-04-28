namespace MineSweeper.Domain; 

public class Square
{ 
    public int File { get; set; }

    public int Rank { get; set; }

    public string Name => (char)(64 + File) + Rank.ToString();

    public bool IsHidden { get; set; }

    public bool IsMine { get; set; }

    public Square(int file, int rank)
    { 
        File = file;
        Rank = rank; 
        IsHidden = true;
        IsMine = false;
    }
}