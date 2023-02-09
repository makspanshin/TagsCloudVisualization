using System;
using System.Collections.Generic;
using System.Text;

namespace TagsCloudVisualization
{
    public interface ITagCloudSettings
    {
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public int FontSize { get; set; }
        public string BackgroundColor { get; set; }
        public string PathToWords { get; set; }
    }
}
