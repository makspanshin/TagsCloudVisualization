using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Helpers
{
    public interface IGenerataorFigure
    {
        public IEnumerable<Size> GetSize(int minValue, int maxValue);
    }
}