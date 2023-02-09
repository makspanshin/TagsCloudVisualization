using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TagsCloudVisualization;
using TagsCloudVisualization.PreprocessorWords;

namespace DebugProject
{
    class Program
    {
        static void Main()
        {
            TagCloudSetting tagCloudSetting = new TagCloudSetting();
            tagCloudSetting.ImageWidth = 1500;
            tagCloudSetting.ImageHeight = 1500;
            tagCloudSetting.PathToWords = "Words.txt";

            var spiral = new ArchimedesSpiral(tagCloudSetting);
            var readerWord = new  ReaderWord(tagCloudSetting);
            var preprocessorWords = new PreprocessorWords();
            preprocessorWords.AddPreprocessor(new PreprocessorToLowercase());
            preprocessorWords.AddPreprocessor(new PreprocessorDeleteSmallWord());
            var painter = new PainterOfRectangles(tagCloudSetting);
            var circularCloudLayouter = new CircularCloudLayouter(tagCloudSetting, spiral);
            var visualizer = new Visualizer(circularCloudLayouter,painter);

            TagCloud tagCloud = new TagCloud(readerWord, preprocessorWords, visualizer);

            tagCloud.Draw();
        }
    }
}