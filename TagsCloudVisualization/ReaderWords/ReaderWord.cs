using System;
using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.ReaderWords
{
    public class ReaderWord : IReaderWords
    {
        private readonly string path;

        public ReaderWord(ITagCloudSettings tagCloudSettings)
        {
            path = tagCloudSettings.PathToWords;
        }

        public IEnumerable<string> ReadWords()
        {
            if (File.Exists(path))
                return File.ReadLines(path);
            throw new Exception("File dont exist");
        }
    }
}