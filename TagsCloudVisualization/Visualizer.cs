using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization
{
    public class Visualizer : IVisualizer
    {
        private readonly ICloudLayouter cloudLayouter;
        private readonly IPainter painter;

        public Visualizer(ICloudLayouter cloudLayouter, IPainter painter)
        {
            this.cloudLayouter = cloudLayouter;
            this.painter = painter;
        }

        public Bitmap Visualize(IEnumerable<string> words)
        {
            MeasurerString measurerString = new MeasurerString();
            var rectangles = new List<Rectangle>();
            foreach (var item in words)
            {
                rectangles.Add(cloudLayouter.PutNextRectangle(measurerString.MeasureString(item, 15)));
            }

            return painter.CreateImage(rectangles, words.ToList());
        }
    }
}
