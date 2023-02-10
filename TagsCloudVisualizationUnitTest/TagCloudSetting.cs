﻿using TagsCloudVisualization;

namespace TagsCloudVisualizationUnitTest
{
    internal class TagCloudSetting : ITagCloudSettings
    {
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public int FontSize { get; set; }
        public string BackgroundColor { get; set; }
        public string PathToWords { get; set; }
    }
}