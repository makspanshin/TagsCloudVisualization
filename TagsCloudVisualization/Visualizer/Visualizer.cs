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
        private readonly ITagCloudSettings tagCloudSettings;

        public Visualizer(ICloudLayouter cloudLayouter, IPainter painter, ITagCloudSettings tagCloudSettings )
        {
            this.cloudLayouter = cloudLayouter;
            this.painter = painter;
            this.tagCloudSettings = tagCloudSettings;
        }

        public Bitmap Visualize(Dictionary<string, int> wordsDict)
        {
            var measurerString = new MeasurerString();
            var rectangles = new List<Rectangle>();
            foreach (var item in wordsDict)
                rectangles.Add(cloudLayouter.PutNextRectangle(measurerString.MeasureString(item.Key, tagCloudSettings.FontSize * item.Value)));

            return painter.CreateImage(rectangles, wordsDict);
        }
    }
}