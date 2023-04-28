using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Domain;

namespace MineSweeper.Tests.DomainTests.SquareTests;

[TestClass]
public class ConstructionTests
{
    [TestMethod]
    public void PropertiesAreSetCorrectlyTest()
    {
        // Arrange
        const int file = 1;
        const int rank = 8;
        const bool  isHidden = true;
        const bool  isMine = false;

        // Act
        var square = new Square(file, rank);

        // Assert
        Assert.AreEqual(file, square.File);
        Assert.AreEqual(rank, square.Rank);
        Assert.AreEqual("A8", square.Name);
        Assert.AreEqual(isHidden, square.IsHidden);
        Assert.AreEqual(isMine, square.IsMine);            
    }
}