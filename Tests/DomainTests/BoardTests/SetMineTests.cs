using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Domain;

namespace MineSweeper.Tests.DomainTests.BoardTests;

[TestClass]
public class SetMineTests
{
    [DataRow("A1", 1, 1, "Positive Diagonal 1")]
    [DataRow("B2", 2, 2, "Positive Diagonal 2")]
    [DataRow("C3", 3, 3, "Positive Diagonal 3")]
    [DataRow("D4", 4, 4, "Positive Diagonal 4")]
    [DataRow("E5", 5, 5, "Positive Diagonal 5")]
    [DataRow("F6", 6, 6, "Positive Diagonal 6")]
    [DataRow("G7", 7, 7, "Positive Diagonal 7")]
    [DataRow("H8", 8, 8, "Positive Diagonal 8")]
    [DataRow("H1", 8, 1, "Top Left")]
    [DataRow("A8", 1, 8, "Bottom Right")]
    [DataTestMethod]
    public void Test(string cellName, int file, int rank, string message)
    {
        // Arrange
        var board = new Board();

        // Act
        board.SetMine(cellName);

        // Assert
        var cell = board.Squares.Single(c => c.File == file && c.Rank == rank);
        Assert.IsTrue(cell.IsMine, message);
        var mineCount = board.Squares.Count(c => c.IsMine);
        Assert.AreEqual(1, mineCount, message);
    }
}