using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TagsCloudVisualization.Interfaces
{
    public interface IVisualizer
    {
         Bitmap Visualize(IEnumerable<string> words);
    }
}
