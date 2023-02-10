using System;
using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Painter;
using TagsCloudVisualization.Saver;

namespace TagsCloudVisualizationUnitTest
{
    class PainterOfRectanglesTest
    {
        private ITagCloudSettings tagCloudSettings;

        [SetUp]
        public void InitCircularCloudLayouter()
        {
            tagCloudSettings = new TagCloudSetting();
            tagCloudSettings.ImageHeight = 200;
            tagCloudSettings.ImageWidth = 200;
        }

        [Test]
        public void CreateImage_ShouldBeThrow_When_SizeCloud_Greatest_SizeImage()
        {
            var painter = new PainterOfRectangles(tagCloudSettings);
            var centrePoint = new Point(100, 100);
            var spiral = new ArchimedesSpiral(tagCloudSettings);
            var circularCloudLayouter = new CircularCloudLayouter(tagCloudSettings, spiral);
            var rectangles = new List<Rectangle>();
            var saver = new SaverImage("test");

            for (int i = 0; i < 100; i++)
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(new Size(100, 100)));
            }

            Action act = () => saver.Execute(painter.CreateImage(rectangles));

            act.Should().Throw<Exception>();
        }

        [Test]
        public void CreateImage_ShouldBeThrow_When_CommandIsNull()
        {
            var painter = new PainterOfRectangles(tagCloudSettings);
            var centrePoint = new Point(10, 10);
            var spiral = new ArchimedesSpiral(tagCloudSettings);
            var circularCloudLayouter = new CircularCloudLayouter(tagCloudSettings, spiral);
            var rectangles = new List<Rectangle>();
            var saver = new SaverImage("test");

            for (int i = 0; i < 100; i++)
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(new Size(100, 100)));
            }

            Action act = () => saver.Execute(painter.CreateImage(rectangles));

            act.Should().Throw<Exception>();
        }
    }
}