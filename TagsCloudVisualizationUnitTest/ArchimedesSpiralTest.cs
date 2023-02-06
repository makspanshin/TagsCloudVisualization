using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization;

namespace TagsCloudVisualizationUnitTest
{
    class ArchimedesSpiralTest
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
        public void CalculateFirstPoint_ShouldBe_In_Centre()
        {
            var centre = new Point(100, 100);
            var spiral = new ArchimedesSpiral(tagCloudSettings);

            spiral.CalculatePoint().Should().Be(centre);
        }
    }
}