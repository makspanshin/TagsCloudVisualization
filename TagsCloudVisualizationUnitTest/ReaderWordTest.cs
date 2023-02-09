using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;
using FluentAssertions;
using System.Text;
using TagsCloudVisualization.ReaderWords;

namespace TagsCloudVisualizationUnitTest
{
    internal class ReaderWordTest
    {

        private const string fileName = "test.txt";
        [SetUp]
        public void GenerationWords()
        {
           using var file =  File.Create(fileName);
           byte[] buffer = Encoding.Default.GetBytes("молодец\nумный\n");
            // запись массива байтов в файл
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
            const string filename = fileName;

            ReaderWord readerWord = new ReaderWord();

            readerWord.ReadWords(filename).Should().NotBeEmpty();
        }

        [Test]
        public void ReadWord_ShouldBeThrowWhen_File_NotExist()
        {
            DeleteFile();

            const string filename = fileName;

            ReaderWord readerWord = new ReaderWord();

            Action act = () => readerWord.ReadWords(filename);

            act.Should().Throw<Exception>();
        }
    }
}
