using System;
using System.Drawing;

namespace TagsCloudVisualization.CloudLayouter
{
    public class ArchimedesSpiral : ISpiral
    {
        private const double TwoPi = 2 * Math.PI;

        private const double Step = 0.1;

        private int nextAngle;

        private Point center;

        public ArchimedesSpiral(ITagCloudSettings tagCloudSettings)
        {
            center = new Point(tagCloudSettings.ImageWidth / 2, tagCloudSettings.ImageHeight / 2);
            nextAngle = 0;
        }

        public Point CalculatePoint()
        {
            var radius = Step * nextAngle / TwoPi;
            var x = (int)(radius * Math.Cos(nextAngle) + center.X);
            var y = (int)(radius * Math.Sin(nextAngle) + center.Y);

            nextAngle++;

            return new Point(x, y);
        }
    }
}