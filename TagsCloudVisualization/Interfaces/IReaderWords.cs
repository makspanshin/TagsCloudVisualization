using System;
using System.Collections.Generic;
using System.Text;

namespace TagsCloudVisualization.Interfaces
{
    internal interface IReaderWords
    {
        IEnumerable<string> ReadWords(string _path);
    }
}
