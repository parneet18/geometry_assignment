using GeometryShapes;


namespace GeometryTests
{
    [TestClass]
    public class square_test1
    {
        [TestMethod]
        public void TestSquareArea_Large()
        {
            // Arrange
            var square = new Square(100);

            // Act
            var result = square.CalculateArea();

            // Assert
            Assert.AreEqual(10000, result);
        }

        [TestMethod]
        public void TestSquarePerimeter_Large()
        {
            // Arrange
            var square = new Square(100);

            // Act
            var result = square.CalculatePerimeter();

            // Assert
            Assert.AreEqual(400, result);
        }
    }
}
