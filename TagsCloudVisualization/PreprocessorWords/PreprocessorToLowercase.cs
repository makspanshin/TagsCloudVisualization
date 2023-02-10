using System.Collections.Generic;

namespace TagsCloudVisualization.PreprocessorWords
{
    public class PreprocessorToLowercase : IPreprocessor
    {
        public IEnumerable<string> Correct(IEnumerable<string> words)
        {
            var correctedWords = new List<string>();
            foreach (var item in words) correctedWords.Add(item.ToLower());
            return correctedWords;
        }
    }
}