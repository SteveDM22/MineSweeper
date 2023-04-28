using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Domain;
using Moq;

namespace MineSweeper.Tests.DomainTests.PlayerTests;

[TestClass]
public class MoveTests
{
    [DataRow("UpArrow", "Up    to ")]
    [DataRow("DownArrow", "Down  to ")]
    [DataRow("LeftArrow", "Left  to ")]
    [DataRow("RightArrow", "Right to ")]
    [DataTestMethod]
    [TestMethod]
    public void MoveReturnsCorrectMessageSuccessTest(string direction, string expectedMessage)
    {
        // Arrange
        var mockBoard = new Mock<IBoard>();

        mockBoard
            .Setup(m => m.MakeMove("D5", direction))
            .Returns(new Square(5, 5));

        var player = new Player(mockBoard.Object)
        {
            Square = { File = 4, Rank = 5 }
        };


        // Act
        var message = player.Move(direction);

        // Assert
        Assert.IsNotNull(message);
        Assert.AreEqual(expectedMessage, message);
        Assert.AreEqual("E5", player.Square.Name);
        Assert.AreEqual(3, player.Lives);
        Assert.AreEqual(1, player.MoveCount);
    }

    [DataRow("UpArrow", "D8", 4, 8)]
    [DataRow("DownArrow", "E1", 5, 1)]
    [DataRow("LeftArrow", "A4", 1, 4)]
    [DataRow("RightArrow", "H4", 8, 4)]
    [DataTestMethod]
    [TestMethod]
    public void MoveReturnsNoMoveFailureTest(string direction, string squareName, int file, int rank)
    {
        // Arrange
        var mockBoard = new Mock<IBoard>();

        mockBoard
            .Setup(m => m.MakeMove(squareName, direction))
            .Returns(new Square(file, rank));

        var player = new Player(mockBoard.Object)
        {
            Square = { File = file, Rank = rank }
        };

        // Act
        var message = player.Move(direction);

        // Assert
        Assert.IsNotNull(message);
        Assert.AreEqual("No Move  ", message);
        Assert.AreEqual(file , player.Square.File);
        Assert.AreEqual(rank, player.Square.Rank);
    }

    [DataRow(true, false, 3)]
    [DataRow(true, true, 2)]
    [DataRow(false, true, 3)]
    [DataRow(false, false, 3)]
    [DataTestMethod]
    [TestMethod]
    public void MineDetectionTest(bool isHidden, bool isMine, int lives)
    {
        // Arrange
        var mockBoard = new Mock<IBoard>();

        var destinationSquare = new Square(4, 5)
        {
            IsHidden = isHidden,
            IsMine = isMine
        };

        mockBoard
            .Setup(m => m.MakeMove(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(destinationSquare);

        var player = new Player(mockBoard.Object);

        // Act
        var message = player.Move("UpArrow");

        // Assert
        Assert.IsNotNull(message);
        Assert.AreEqual(lives, player.Lives);
    }
}