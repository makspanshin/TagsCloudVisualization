using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Visualizer
{
    public interface IVisualizer
    {
        Bitmap Visualize(Dictionary<string, int> wordsDict);
    }
}
