using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.PreprocessorWords
{
    public class PreprocessorWords : IPreprocessorWords
    {
        public PreprocessorWords(IPreprocessor[] preprocessors)
        {
            this.Preprocessors = preprocessors.ToList();
        }

        public PreprocessorWords()
        {

        }

        public List<IPreprocessor> Preprocessors { get; } = new();

        public void AddPreprocessor(IPreprocessor preprocessor)
        {
            if (!Preprocessors.Contains(preprocessor))
                Preprocessors.Add(preprocessor);
        }

        public void RemovePreprocessor(IPreprocessor preprocessor)
        {
            Preprocessors.Remove(preprocessor);
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            var processedWords = words;
            foreach (var item in Preprocessors) processedWords = item.Correct(processedWords);

            return processedWords;
        }
    }
}