using System.Diagnostics;
using System.Linq;
using TagsCloudVisualization.PreprocessorWords;
using TagsCloudVisualization.ReaderWords;
using TagsCloudVisualization.Saver;
using TagsCloudVisualization.Visualizer;

namespace TagsCloudVisualization
{
    public class TagCloud : ITagCloud
    {
        private readonly IPreprocessorWords preprocessorWords;
        private readonly IReaderWords readerWords;
        private readonly IVisualizer visualizer;

        //var centrePoint = new Point(750, 750);

        //TODO объежеить в один класс 
        public TagCloud(IReaderWords readerWords, IPreprocessorWords preprocessorWords, IVisualizer visualizer)
        {
            this.readerWords = readerWords;
            this.preprocessorWords = preprocessorWords;
            this.visualizer = visualizer;
        }

        public void Draw()
        {
            var words = readerWords.ReadWords();
            words = preprocessorWords.Apply(words);

            var saver = new SaverImage("CircularCloudLayouter1.png");

            //Dictionary<string, int> wordsDict = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var wordsDict = words.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count())
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            saver.Execute(visualizer.Visualize(wordsDict));
            var openImageProcess = new Process();
            openImageProcess.StartInfo = new ProcessStartInfo("CircularCloudLayouter1.png")
            {
                UseShellExecute = true
            };
            openImageProcess.Start();
        }
    }
}