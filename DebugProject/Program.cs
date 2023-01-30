using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TagsCloudVisualization;

namespace DebugProject
{
    class Program
    {
        static void Main()
        {
            var painter = new PainterOfRectangles(new Size(1500, 1500));
            var centrePoint = new Point(750, 750);
            var spiral = new ArchimedesSpiral(centrePoint);
            var circularCloudLayouter = new CircularCloudLayouter(centrePoint, spiral);
            var rectangles = new List<Rectangle>();
            var saver = new SaverImage("CircularCloudLayouter1.png");

            var generatorRectangle = new GeneratorOfRectangles();

            /*for (int i = 0; i < 2000; i++)
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(generatorRectangle.GetSize(10, 10)));
            }*/

            foreach (var item in generatorRectangle.GetSize(3, 50))
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(item));
                if (rectangles.Count > 2000)
                    break;
            }

            painter.CreateImage(rectangles, saver);

            var openImageProcess = new Process();
            openImageProcess.StartInfo = new ProcessStartInfo("CircularCloudLayouter1.png")
            {
                UseShellExecute = true
            };
            openImageProcess.Start();
        }
    }
}