using System;
using System.Collections.Generic;
using System.Text;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization
{
    public  class TagCloud
    {
        private readonly IReaderWords readerWords;
        private readonly IPreprocessorWords preprocessorWords;
        private readonly ICloudLayouter cloudLayouter;
        private readonly IPainter painter;
        private readonly ISpiral spiral;
        //var centrePoint = new Point(750, 750);

        public TagCloud(IReaderWords readerWords, IPreprocessorWords preprocessorWords, ICloudLayouter cloudLayouter, IPainter painter, ISpiral spiral)
        {
            this.readerWords = readerWords;
            this.preprocessorWords = preprocessorWords;
            this.cloudLayouter = cloudLayouter;
            this.painter = painter;
            this.spiral = spiral;
        }


    }
}
