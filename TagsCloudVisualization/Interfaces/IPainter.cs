using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Interfaces
{
    public interface IPainter
    {
        public Bitmap CreateImage(List<Rectangle> rectangles, List<string> words);
    }
}