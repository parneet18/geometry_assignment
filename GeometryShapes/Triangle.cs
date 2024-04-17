

namespace GeometryShapes
{
    public class Triangle : IShape
    {
        private readonly double side1;
        private readonly double side2;
        private readonly double side3;

        public Triangle(double side1, double side2, double side3)
        {
            if (!IsValidTriangle(side1, side2, side3))
            {
                throw new ArgumentException("Invalid triangle dimensions.");
            }

            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public double CalculateArea()
        {
            double s = (side1 + side2 + side3) / 2;
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }

        public double CalculatePerimeter()
        {
            return side1 + side2 + side3;
        }

        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
