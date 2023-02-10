using System;
using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization;
using TagsCloudVisualization.ReaderWords;

namespace TagsCloudVisualizationUnitTest
{
    internal class ReaderWordTest
    {
        private const string fileName = "Word.txt";
        private ITagCloudSettings tagCloudSettings;

        [SetUp]
        public void GenerationWords()
        {
            tagCloudSettings = new TagCloudSetting();
            tagCloudSettings.ImageHeight = 200;
            tagCloudSettings.ImageWidth = 200;
            tagCloudSettings.PathToWords = fileName;

            using var file = File.Create(fileName);
            var buffer = Encoding.Default.GetBytes("молодец\nумный\n");
            file.Write(buffer, 0, buffer.Length);
        }

        [TearDown]
        public void DeleteFile()
        {
            File.Delete(fileName);
        }

        [Test]
        public void ReadWord_ShouldBe_Ok()
        {
            var readerWord = new ReaderWord(tagCloudSettings);

            readerWord.ReadWords().Should().NotBeEmpty();
        }

        [Test]
        public void ReadWord_ShouldBeThrowWhen_File_NotExist()
        {
            DeleteFile();

            var readerWord = new ReaderWord(tagCloudSettings);

            Action act = () => readerWord.ReadWords();

            act.Should().Throw<Exception>();
        }
    }
}