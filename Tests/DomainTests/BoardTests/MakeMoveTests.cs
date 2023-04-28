using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Domain;

namespace MineSweeper.Tests.DomainTests.BoardTests;

[TestClass]
public class MakeMoveTests
{
    [DataRow("A1", "A2", "UpArrow", "Up Move")]
    [DataRow("B1", "B1", "DownArrow", "Down Move")]
    [DataRow("B8", "A8", "LeftArrow", "Left Move")]
    [DataRow("D4", "E4", "RightArrow", "Right Move")]
    [DataRow("A8", "A8",  "UpArrow", "Up No Move")]
    [DataRow("F1", "F1", "DownArrow", "Down No Move")]
    [DataRow("A7", "A7", "LeftArrow", "Left No Move")]
    [DataRow("H8", "H8", "RightArrow", "Right No Move")]
    [DataRow("H4", "H4", "NotAnArrow", "Not Arrow No Move")]
    [DataRow("A0", "A1", "UpArrow", "Initial Move")]
    [DataTestMethod]
    public void MoveReturnsCorrectCellTest(string name, string expectedName, string direction, string message)
    {
        // Arrange
        var board = new Board();

        // Act
        var destinationCell = board.MakeMove(name, direction);

        // Assert
        Assert.AreEqual(expectedName, destinationCell.Name, message);
    }
}
