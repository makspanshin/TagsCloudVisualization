using System.Collections.Generic;

namespace TagsCloudVisualization.PreprocessorWords
{
    public interface IPreprocessor
    {
        IEnumerable<string> Correct(IEnumerable<string> words);
    }
}