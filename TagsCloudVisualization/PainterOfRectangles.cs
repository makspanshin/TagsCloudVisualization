﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization
{
    public class PainterOfRectangles : IPainter
    {
        private Size pictSize;

        public PainterOfRectangles(ITagCloudSettings tagCloudSettings)
        {
            pictSize = new Size(tagCloudSettings.ImageWidth, tagCloudSettings.ImageHeight);
        }

        public Bitmap CreateImage(List<Rectangle> rectangles, List<string> words)
        {

            if (!IsCorrectSizeImage(rectangles))
            {
                throw new Exception("Размеры изображения не подходят, чтобы вписать прямоугольники");
            }

            using Bitmap bmp = new Bitmap(pictSize.Width, pictSize.Height);

            using Graphics graphics = Graphics.FromImage(bmp);

            using Pen penRectangle = new Pen(Color.Blue, .5f);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;

            //foreach (var rectangle in rectangles)
            //{
            //    graphics.DrawRectangle(penRectangle, rectangle);

            //    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            //    graphics.DrawString("Текст по центру", new Font("Times", 15), Brushes.Black, rectangle, sf);
            //}
            for (int i = 0; i < rectangles.Count; i++)
            {
                graphics.DrawRectangle(penRectangle, rectangles[i]);

                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                graphics.DrawString(words[i], new Font("Times", 15), Brushes.Black, rectangles[i], sf);
            }

            return new Bitmap(bmp);
        }

        private bool IsCorrectSizeImage(List<Rectangle> rectangles)
        {
            if (rectangles.Max(rectangle => rectangle.X) > pictSize.Height ||
                rectangles.Max(rectangle => rectangle.X) > pictSize.Width)
            {
                return false;
            }

            return true;
        }
    }
}