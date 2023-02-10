using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace TagsCloudVisualization.Painter
{
    public class PainterOfRectangles : IPainter
    {
        private Size pictSize;

        public PainterOfRectangles(ITagCloudSettings tagCloudSettings)
        {
            pictSize = new Size(tagCloudSettings.ImageWidth, tagCloudSettings.ImageHeight);
        }

        public Bitmap CreateImage(List<Rectangle> rectangles, Dictionary<string, int> wordsDict)
        {
            if (!IsCorrectSizeImage(rectangles))
                throw new Exception("Размеры изображения не подходят, чтобы вписать прямоугольники");

            using var bmp = new Bitmap(pictSize.Width, pictSize.Height);

            using var graphics = Graphics.FromImage(bmp);

            using var penRectangle = new Pen(Color.Blue, .5f);

            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (var i = 0; i < rectangles.Count; i++)
            {
                //graphics.DrawRectangle(penRectangle, rectangles[i]);

                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                graphics.DrawString(wordsDict.Keys.ToArray()[i], new Font("Times", 15 * wordsDict.Values.ToArray()[i]),
                    Brushes.Black, rectangles[i], sf);
            }

            return new Bitmap(bmp);
        }

        public Bitmap CreateImage(List<Rectangle> rectangles)
        {
            if (!IsCorrectSizeImage(rectangles))
                throw new Exception("Размеры изображения не подходят, чтобы вписать прямоугольники");

            using var bmp = new Bitmap(pictSize.Width, pictSize.Height);

            using var graphics = Graphics.FromImage(bmp);

            using var penRectangle = new Pen(Color.Blue, .5f);

            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (var i = 0; i < rectangles.Count; i++)
                graphics.DrawRectangle(penRectangle, rectangles[i]);

            return new Bitmap(bmp);
        }

        private bool IsCorrectSizeImage(List<Rectangle> rectangles)
        {
            if (rectangles.Max(rectangle => rectangle.X) > pictSize.Height ||
                rectangles.Max(rectangle => rectangle.X) > pictSize.Width)
                return false;

            return true;
        }
    }
}