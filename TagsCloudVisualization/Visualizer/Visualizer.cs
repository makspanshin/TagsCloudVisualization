using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Painter;

namespace TagsCloudVisualization.Visualizer
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

        public Bitmap Visualize(Dictionary<string, int> wordsDict)
        {
            var measurerString = new MeasurerString();
            var rectangles = new List<Rectangle>();
            foreach (var item in wordsDict)
                rectangles.Add(cloudLayouter.PutNextRectangle(measurerString.MeasureString(item.Key, 15 * item.Value)));

            return painter.CreateImage(rectangles, wordsDict);
        }
    }
}