using CommandLine;
using TagsCloudVisualization;

namespace DebugProject
{
    internal class TagCloudSetting : ITagCloudSettings
    {
        [Option('h', "imageHeight", Default = 1080, HelpText = "Set image height")]
        public int ImageHeight { get; set; }

        [Option('w', "imageWidth", Default = 1920, HelpText = "Set image width")]
        public int ImageWidth { get; set; }

        [Option('s', "fontSize", Default = 20, HelpText = "Set font size")]
        public int FontSize { get; set; }

        [Option('b', "backgroundColor", Default = "#ffff6347", HelpText = "Set background color")]
        public string BackgroundColor { get; set; }

        [Option('i', "inputPath", Required = true, HelpText = "File path which provides words for tags")]
        public string PathToWords { get; set; }

        public static ITagCloudSettings Parse(string[] args)
        {
            return ArgumentsParser.Parse<TagCloudSetting>(args);
        }
    }
}