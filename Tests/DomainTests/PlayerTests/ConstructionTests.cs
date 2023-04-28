using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Domain;
using Moq;

namespace MineSweeper.Tests.DomainTests.PlayerTests;

[TestClass]
public class ConstructionTests
{
    [TestMethod]
    public void PlayerIsConstructedCorrectlyTest()
    {
        // Arrange
        var mockBoard = new Mock<IBoard>();

        // Act
        var player = new Player(mockBoard.Object);

        // Assert
        Assert.IsNotNull(player);
        Assert.AreEqual(3, player.Lives);
        Assert.AreEqual(0, player.MoveCount);
        Assert.AreEqual(0, player.Square.File);
        Assert.AreEqual(0, player.Square.Rank);
        Assert.IsTrue(player.Square.IsHidden);
        Assert.IsFalse(player.Square.IsMine);
        Assert.IsTrue(player.IsAlive);
        Assert.IsFalse(player.Finished);
    }
}