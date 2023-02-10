using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.PreprocessorWords;

namespace TagsCloudVisualizationUnitTest
{
    internal class PreprocessorWordsTest
    {
        [Test]
        public void AddPreprocessor_ShouldBe_AddedPreprocessor()
        {
            var preprocessorWords = new PreprocessorWords();

            IPreprocessor prepocessor = new PreprocessorToLowercase();

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.Preprocessors.Should().NotBeEmpty();
        }

        [Test]
        public void AddPreprocessor_ShouldBe_Once()
        {
            var preprocessorWords = new PreprocessorWords();

            IPreprocessor prepocessor = new PreprocessorToLowercase();

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.Preprocessors.Should().HaveCount(1);
        }

        [Test]
        public void AddPreprocessor_ShouldBe_RemovedPreprocessor()
        {
            var preprocessorWords = new PreprocessorWords();

            IPreprocessor prepocessor = new PreprocessorToLowercase();

            preprocessorWords.AddPreprocessor(prepocessor);

            preprocessorWords.RemovePreprocessor(prepocessor);

            preprocessorWords.Preprocessors.Should().BeEmpty();
        }

        [Test]
        public void PreprocessorToLowercase_Correct_ShouldBe_Ok()
        {
            var preprocessor = new PreprocessorToLowercase();
            var words = new List<string> {"SAssss", "sssss", "SSSSSS", "ASDASDA"};

            words = (List<string>) preprocessor.Correct(words);

            foreach (var item in words) item.Should().BeLowerCased();
        }

        [Test]
        public void PreprocessorDeleteSmallWord_Dont_Should_Simple_Words()
        {
            IPreprocessor preprocessor = new PreprocessorDeleteSmallWord();
            var words = new List<string> {"в", "ты", "на", "ASDASDA", "test", "он"};

            words = (List<string>) preprocessor.Correct(words);

            var afteCorrectWords = new List<string> {"ASDASDA", "test"};
            words.Should().BeEquivalentTo(afteCorrectWords);
        }

        [Test]
        public void ApplyPreprocessors_ShouldBe_Ok()
        {
            var preprocessorWords = new PreprocessorWords();

            IPreprocessor preprocessorToLowercase = new PreprocessorToLowercase();

            IPreprocessor preprocessorDeleteSmallWord = new PreprocessorDeleteSmallWord();

            preprocessorWords.AddPreprocessor(preprocessorToLowercase);

            preprocessorWords.AddPreprocessor(preprocessorDeleteSmallWord);

            var words = new List<string> {"в", "ты", "на", "ASDASDA", "test", "он"};
            words = (List<string>) preprocessorWords.Apply(words);

            var afteCorrectWords = new List<string> {"asdasda", "test"};

            words.Should().BeEquivalentTo(afteCorrectWords);
        }
    }
}