using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TagsCloudVisualization;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Helpers;
using TagsCloudVisualization.Painter;
using TagsCloudVisualization.ReaderWords;
using TagsCloudVisualization.Saver;

namespace TagsCloudVisualizationUnitTest
{
    public class TagsCloudVisualizationTest
    {
        private const string PathFolderFailedTest = "FailedTest";
        private ArchimedesSpiral archimedesSpiral;
        private CircularCloudLayouter circularCloudLayouter;
        private PainterOfRectangles painterOfRectangles;
        private List<Rectangle> rectangles;
        private ITagCloudSettings tagCloudSettings;

        [SetUp]
        public void InitCircularCloudLayouter()
        {
            tagCloudSettings = new TagCloudSetting();
            tagCloudSettings.ImageHeight = 1000;
            tagCloudSettings.ImageWidth = 1000;
            //centrPoint = new Point(500, 500);
            archimedesSpiral = new ArchimedesSpiral(tagCloudSettings);
            circularCloudLayouter = new CircularCloudLayouter(tagCloudSettings, archimedesSpiral);
            rectangles = new List<Rectangle>();
        }

        [TearDown]
        public void SaveImageWithFailCircularCloudLayouter()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status is TestStatus.Failed)
            {
                Directory.CreateDirectory(PathFolderFailedTest);
                var nameFile = PathFolderFailedTest + "//" + TestContext.CurrentContext.Test.FullName + "Failed.png";
                var saver = new SaverImage(nameFile);
                painterOfRectangles = new PainterOfRectangles(tagCloudSettings);
                saver.Execute(painterOfRectangles.CreateImage(rectangles));
            }
        }

        [TestCase(-10, -10, TestName = "Negative size")]
        [TestCase(0, 0, TestName = "Size is Empty")]
        [TestCase(10, 0, TestName = "Weight = zero")]
        public void PutNextRectangle_ShouldBeThrowWhen(int height, int width)
        {
            Action act = () => circularCloudLayouter.PutNextRectangle(new Size(width, height));

            act.Should().Throw<Exception>();
        }

        [Test]
        public void PutNextRectangle_RectanglesShouldBeHaveUniqueCoordinates()
        {
            for (var i = 0; i < 1000; i++) rectangles.Add(circularCloudLayouter.PutNextRectangle(new Size(10, 10)));

            rectangles.Should().OnlyHaveUniqueItems();
        }

        [TestCase(10, TestName = "10 Rectangles")]
        [TestCase(1000, TestName = "1000 Rectangles")]
        [TestCase(2000, TestName = "2000 Rectangles")]
        public void DensityCloud_ShouldBeBig(int countRectangle)
        {
            var generator = new GeneratorOfRectangles();

            foreach (var item in generator.GetSize(10, 10))
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(item));
                if (rectangles.Count > countRectangle)
                    break;
            }

            var square = Math.Pow(Radius(), 2) * Math.PI;

            var densityCloud = SquareRectangles() / square * 100;

            densityCloud.Should().BeGreaterThan(70);
        }

        [TestCase(10, TestName = "10 Rectangles Random Size")]
        [TestCase(1000, TestName = "1000 Rectangles Random Size")]
        [TestCase(2000, TestName = "2000 Rectangles Random Size")]
        public void DensityCloud_Random_Size_ShouldBeBig(int countRectangle)
        {
            var generator = new GeneratorOfRectangles();

            foreach (var item in generator.GetSize(10, 20))
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(item));
                if (rectangles.Count > countRectangle)
                    break;
            }

            var square = Math.Pow(Radius(), 2) * Math.PI;

            var densityCloud = SquareRectangles() / square * 100;

            densityCloud.Should().BeGreaterThan(70);
        }

        private int Radius()
        {
            if (rectangles == null)
                throw new Exception("rectangles is null");

            var xMax = rectangles.Max(rectangle => Math.Abs(rectangle.X));
            var yMax = rectangles.Max(rectangle => Math.Abs(rectangle.Y));

            var distanceToXMax = Math.Abs(xMax) - Math.Abs(tagCloudSettings.ImageWidth / 2);
            var distanceToYMax = Math.Abs(yMax) - Math.Abs(tagCloudSettings.ImageHeight / 2);

            return distanceToXMax > distanceToYMax ? distanceToXMax : distanceToYMax;
        }

        private double SquareRectangles()
        {
            if (rectangles == null)
                throw new Exception("rectangles is null");

            return rectangles.Sum(rectangle => rectangle.Square());
        }
    }
}