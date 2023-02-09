using System.Drawing;

namespace TagsCloudVisualization.Helpers
{
    public static class SquareRectangle
    {
        public static double Square(this Rectangle rectangle)
        {
            return rectangle.Height * rectangle.Width;
        }
    }
}