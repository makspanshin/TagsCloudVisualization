using System.Collections.Generic;

namespace TagsCloudVisualization.PreprocessorWords
{
    public class PreprocessorDeleteSmallWord : IPreprocessor
    {
        private readonly HashSet<string> ignoreWords = new()
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
            "у"
        };

        public IEnumerable<string> Correct(IEnumerable<string> words)
        {
            var correctedWords = new List<string>();
            foreach (var item in words)
                if (!ignoreWords.Contains(item))
                    correctedWords.Add(item);
            return correctedWords;
        }
    }
}