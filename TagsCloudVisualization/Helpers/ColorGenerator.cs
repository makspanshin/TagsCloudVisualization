using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TagsCloudVisualization.Helpers
{
    public class ColorGenerator
    {
        private Random random = new Random();
        public ColorGenerator()
        {
        }

        public Color Get()
        {
            return Color.FromArgb(255,random.Next(256), random.Next(256), random.Next(256));
        }
    }
}
