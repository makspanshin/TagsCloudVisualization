using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization
{
    public class ReaderWord : IReaderWords
    {
        public ReaderWord()
        {
        }

        public IEnumerable<string> ReadWords(string _path)
        {
            if (File.Exists(_path))
                return File.ReadLines(_path);
            else
                throw new Exception("File dont exist");
        }
    }
}
