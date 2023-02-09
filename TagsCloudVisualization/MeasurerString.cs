using System.Drawing;

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
