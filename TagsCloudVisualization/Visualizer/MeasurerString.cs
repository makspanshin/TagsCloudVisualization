using System.Drawing;

namespace TagsCloudVisualization.Visualizer
{
    internal class MeasurerString
    {
        public Size MeasureString(string word, int sizeFont)
        {
            using var font = new Font("Times", sizeFont);

            return new Size((int) font.Size * word.Length, font.Height);
        }
    }
}