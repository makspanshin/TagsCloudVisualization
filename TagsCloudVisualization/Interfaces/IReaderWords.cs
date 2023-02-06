using System;
using System.Collections.Generic;
using System.Text;

namespace TagsCloudVisualization.Interfaces
{
    public interface IReaderWords
    {
        IEnumerable<string> ReadWords(string _path);
    }
}
