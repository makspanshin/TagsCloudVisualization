using System.Collections.Generic;

namespace TagsCloudVisualization.Interfaces
{
    public interface IPreprocessor
    {
        IEnumerable<string> Correct(IEnumerable<string> words);
    }
}
