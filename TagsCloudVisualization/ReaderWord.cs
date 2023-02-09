using System;
using System.Collections.Generic;
using System.IO;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization
{
    public class ReaderWord : IReaderWords
    {
        private string path;
        public ReaderWord(ITagCloudSettings tagCloudSettings)
        {
            path = tagCloudSettings.PathToWords;
        }

        public IEnumerable<string> ReadWords()
        {
            if (File.Exists(path))
                return File.ReadLines(path);
            else
                throw new Exception("File dont exist");
        }
    }
}
