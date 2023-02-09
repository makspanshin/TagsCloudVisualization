using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TagsCloudVisualization
{
    internal class MeasurerString
    {
        public MeasurerString()
        {
        }

        public Size MeasureString(string word, int sizeFont)
        {
            using Font font = new Font("Times", sizeFont);

            return new Size((int)font.Size * word.Length, font.Height);
        }
    }
}
