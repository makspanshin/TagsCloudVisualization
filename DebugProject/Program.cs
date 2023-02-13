using Autofac;
using TagsCloudVisualization;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Painter;
using TagsCloudVisualization.PreprocessorWords;
using TagsCloudVisualization.ReaderWords;
using TagsCloudVisualization.Visualizer;

namespace DebugProject
{
    internal class Program
    {
        private static IContainer Container { get; set; }

        private static void Main(string[] args)
        {
            var tagCloudSetting = TagCloudSetting.Parse(args);
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