using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Painter
{
    public interface IPainter
    {
        public Bitmap CreateImage(List<Rectangle> rectangles, List<string> words);
    }
}