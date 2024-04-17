using GeometryShapes;

namespace GeometryTests


{

[TestClass]
public class rectangle_test
{
   

    [TestMethod]
    public void TestRectanglePerimeter_VeryLarge()
    {
        // Arrange
        var rectangle = new Rectangle(1000, 500);

        // Act
        var result = rectangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(3000, result);
    }

    [TestMethod]
    public void TestRectangleArea_Thin()
    {
        // Arrange
        var rectangle = new Rectangle(50, 1);

        // Act
        var result = rectangle.CalculateArea();

        // Assert
        Assert.AreEqual(50, result);
    }
}
}
