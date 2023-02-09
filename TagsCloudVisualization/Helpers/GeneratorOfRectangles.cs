using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Helpers
{
    public class GeneratorOfRectangles : IGenerataorFigure
    {
        private Random rnd = new Random();

        public IEnumerable<Size> GetSize(int minValue, int maxValue)
        {
            while (true)
            {
                yield return new Size(rnd.Next(minValue, maxValue), rnd.Next(minValue, maxValue));
            }
        }
    }
}