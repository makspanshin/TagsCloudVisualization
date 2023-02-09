using System.Collections.Generic;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization.PreprocessorWords
{
    public class PreprocessorDeleteSmallWord : IPreprocessor
    {
        private HashSet<string> ignoreWords = new HashSet<string>()
        {
            "в",
            "ты",
            "на",
            "он",
            "без",
            "до",
            "для",
            "за",
            "через",
            "над",
            "по",
            "из",
            "у",
        };

        public PreprocessorDeleteSmallWord()
        {
        }

        public IEnumerable<string> Correct(IEnumerable<string> words)
        {
            List<string> correctedWords = new List<string>();
            foreach (var item in words)
            {
                if (!ignoreWords.Contains(item))
                    correctedWords.Add(item);
            }
            return correctedWords;
        }
    }
}
