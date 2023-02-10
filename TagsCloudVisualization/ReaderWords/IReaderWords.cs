using System.Collections.Generic;

namespace TagsCloudVisualization.ReaderWords
{
    public interface IReaderWords
    {
        IEnumerable<string> ReadWords();
    }
}