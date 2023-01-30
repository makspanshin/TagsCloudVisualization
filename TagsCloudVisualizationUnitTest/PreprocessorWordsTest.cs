using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Interfaces;
using TagsCloudVisualization.PreprocessorWords;

namespace TagsCloudVisualizationUnitTest
{
    internal class PreprocessorWordsTest
    {

        [Test]
        public void AddPreprocessor_ShouldBe_AddedPreprocessor()
        {
            PreprocessorWords preprocessorWords = new PreprocessorWords();

            IPreprocessor prepocessor = new  PreprocessorToLowercase();

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.Preprocessors.Should().NotBeEmpty();
        }

        [Test]
        public void AddPreprocessor_ShouldBe_Once()
        {
            PreprocessorWords preprocessorWords = new PreprocessorWords();

            IPreprocessor prepocessor = new PreprocessorToLowercase();

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.Preprocessors.Should().HaveCount(1);
        }

        [Test]
        public void AddPreprocessor_ShouldBe_RemovedPreprocessor()
        {
            PreprocessorWords preprocessorWords = new PreprocessorWords();

            IPreprocessor prepocessor = new PreprocessorToLowercase();

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.RemovePreprocessor(prepocessor);

            preprocessorWords.Preprocessors.Should().BeEmpty();
        }

        [Test]
        public void ApplePreprocessors_ShouldBe_Ok()
        {

        }

        [Test]
        public void Preprocessor_Correct_ShouldBe_Ok()
        {

        }

    }
}
