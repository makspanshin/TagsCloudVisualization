﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TagsCloudVisualization.Interfaces
{
    public interface IPreprocessorWords
    {
        void AddPreprocessor(IPreprocessor preprocessor);

        void RemovePreprocessor(IPreprocessor preprocessor);

        void Apply(IEnumerable<string> words);

    }
}
