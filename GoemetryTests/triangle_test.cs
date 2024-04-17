

using GeometryShapes;


namespace GeometryTests;




[TestClass]
public class triangle_test
{
    [TestMethod]
    public void TestTriangleArea_EquilateralLarge()
    {
        // Arrange
        var triangle = new Triangle(100, 100, 100);

        // Act
        var result = triangle.CalculateArea();

        // Assert
        Assert.AreEqual(4330.127018922194, result, 0.0001);
    }

    [TestMethod]
    public void TestTrianglePerimeter_EquilateralLarge()
    {
        // Arrange
        var triangle = new Triangle(100, 100, 100);

        // Act
        var result = triangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(300, result);
    }

}

