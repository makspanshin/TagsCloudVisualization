using System.Collections.Generic;
using System.Diagnostics;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization
{
    public class TagCloud : ITagCloud
    {
        private readonly IReaderWords readerWords;
        private readonly IPreprocessorWords preprocessorWords;
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
            IEnumerable<string> words = readerWords.ReadWords();
            words = preprocessorWords.Apply(words);

            var saver = new SaverImage("CircularCloudLayouter1.png");

            saver.Execute(visualizer.Visualize(words));
            var openImageProcess = new Process();
            openImageProcess.StartInfo = new ProcessStartInfo("CircularCloudLayouter1.png")
            {
                UseShellExecute = true
            };
            openImageProcess.Start();

        }




    }
}
