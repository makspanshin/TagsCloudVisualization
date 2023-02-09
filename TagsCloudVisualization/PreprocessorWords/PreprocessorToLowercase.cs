using System.Collections.Generic;

namespace TagsCloudVisualization.PreprocessorWords
{
    public class PreprocessorToLowercase : IPreprocessor
    {
        public PreprocessorToLowercase()
        {
        }

        public IEnumerable<string> Correct(IEnumerable<string> words)
        {
            List<string> correctedWords = new List<string>();
            foreach (var item in words)
            {
                correctedWords.Add(item.ToLower());
            }
            return correctedWords;
        }
    }
}
