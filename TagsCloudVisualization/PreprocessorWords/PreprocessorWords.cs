using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.PreprocessorWords
{
    public class PreprocessorWords : IPreprocessorWords
    {
        private List<IPreprocessor> preprocessors = new List<IPreprocessor>();

        public PreprocessorWords(IPreprocessor[] preprocessors)
        {
            this.preprocessors = preprocessors.ToList();
        }

        public List<IPreprocessor> Preprocessors { get => preprocessors; }

        public void AddPreprocessor(IPreprocessor preprocessor)
        {
            if (!preprocessors.Contains(preprocessor))
                preprocessors.Add(preprocessor);
        }

        public void RemovePreprocessor(IPreprocessor preprocessor)
        {
            preprocessors.Remove(preprocessor);
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            IEnumerable<string> processedWords = words;
            foreach (var item in preprocessors)
            {
                processedWords = item.Correct(processedWords);
            }

            return processedWords;
        }
    }
}
