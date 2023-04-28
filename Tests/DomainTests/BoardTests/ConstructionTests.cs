using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Domain;

namespace MineSweeper.Tests.DomainTests.BoardTests;

[TestClass]
public class ConstructionTests
{
    [TestMethod]
    public void BoardIsConstructedCorrectlyTest()
    {
        // Arrange

        // Act
        var board = new Board();

        // Assert
        Assert.IsNotNull(board);
        Assert.AreEqual(64, board.Squares.Count);
    }

    [DataRow(1, 1, "A1", "Positive Diagonal 1")]
    [DataRow(2, 2, "B2", "Positive Diagonal 2")]
    [DataRow(3, 3, "C3", "Positive Diagonal 3")]
    [DataRow(4, 4, "D4", "Positive Diagonal 4")]
    [DataRow(5, 5, "E5", "Positive Diagonal 5")]
    [DataRow(6, 6, "F6", "Positive Diagonal 6")]
    [DataRow(7, 7, "G7", "Positive Diagonal 7")]
    [DataRow(8, 8, "H8", "Positive Diagonal 8")]
    [DataRow(8, 1, "H1", "Top Left")]
    [DataRow(1, 8, "A8", "Bottom Right")]
    [DataTestMethod]
    public void CellsAreInitiatedCorrectlyTest(int file, int rank, string name, string message)
    {
        // Arrange")]
        var board = new Board();

        // Act
        var cell = board.Squares.Single(c => c.File == file && c.Rank == rank);

        // Assert
        Assert.AreEqual(file, cell.File, message);
        Assert.AreEqual(rank, cell.Rank, message);
        Assert.AreEqual(name, cell.Name, message);
        Assert.IsTrue(cell.IsHidden, message);
        Assert.IsFalse(cell.IsMine, message);
    }
}