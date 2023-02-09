using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Interfaces
{
    public interface IVisualizer
    {
        Bitmap Visualize(IEnumerable<string> words);
    }
}
