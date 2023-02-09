using System.Collections.Generic;

namespace TagsCloudVisualization.Interfaces
{
    public interface IReaderWords
    {
        IEnumerable<string> ReadWords();
    }
}
