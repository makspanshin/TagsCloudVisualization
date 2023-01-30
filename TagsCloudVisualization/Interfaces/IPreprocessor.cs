using System;
using System.Collections.Generic;
using System.Text;

namespace TagsCloudVisualization.Interfaces
{
    public interface IPreprocessor
    {
        IEnumerable<string> Correct(IEnumerable<string> words);
    }
}
