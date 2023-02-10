using System.Collections.Generic;

namespace TagsCloudVisualization.PreprocessorWords
{
    public interface IPreprocessorWords
    {
        void AddPreprocessor(IPreprocessor preprocessor);

        void RemovePreprocessor(IPreprocessor preprocessor);

        IEnumerable<string> Apply(IEnumerable<string> words);
    }
}