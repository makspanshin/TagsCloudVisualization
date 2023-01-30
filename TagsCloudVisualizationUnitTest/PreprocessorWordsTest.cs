using FluentAssertions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public void PreprocessorToLowercase_Correct_ShouldBe_Ok()
        {
            PreprocessorToLowercase preprocessor = new PreprocessorToLowercase();
            List<string> words = new List<string>() { "SAssss", "sssss", "SSSSSS", "ASDASDA" };

            words = (List<string>)preprocessor.Correct(words);

            foreach (var item in words)
            {
                item.Should().BeLowerCased();
            }
        }

    }
}
