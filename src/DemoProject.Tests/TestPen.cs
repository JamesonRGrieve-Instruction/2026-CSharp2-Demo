using DemoProject;
namespace DemoProject.Tests;

public class PenTests
{
    [Fact]
    public void TestWrite()
    {
        // Arrange
        Pen myPen = new Pen("Bic", "Red");

        // Act
        myPen.write(100);

        // Assert
        Assert.Equal(50f, myPen.InkLevel);
    }
}
