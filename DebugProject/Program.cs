using Autofac;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TagsCloudVisualization;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Painter;
using TagsCloudVisualization.PreprocessorWords;
using TagsCloudVisualization.ReaderWords;
using TagsCloudVisualization.Visualizer;

namespace DebugProject
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main()
        {
            var tagCloudSetting = new TagCloudSetting();
            tagCloudSetting.ImageWidth = 1500;
            tagCloudSetting.ImageHeight = 1500;
            tagCloudSetting.PathToWords = "Words.txt";

            Container = Configure(tagCloudSetting);
            Container.Resolve<ITagCloud>().Draw();
        }

        private static IContainer Configure(ITagCloudSettings tagCloudSettings)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ArchimedesSpiral>().As<ISpiral>();
            builder.RegisterType<ReaderWord>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<PreprocessorDeleteSmallWord>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<PreprocessorToLowercase>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<PreprocessorWords>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<PainterOfRectangles>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<CircularCloudLayouter>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<Visualizer>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<TagCloud>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterInstance(tagCloudSettings).AsImplementedInterfaces().SingleInstance();
            return builder.Build();
        }

    }
}