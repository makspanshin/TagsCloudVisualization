using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Interfaces
{
    public interface IGenerataorFigure
    {
        public IEnumerable<Size> GetSize(int minValue, int maxValue);
    }
}