﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization.CloudLayouter
{
    public class CircularCloudLayouter : ICloudLayouter
    {
        private readonly List<Rectangle> rectangles;
        private readonly ISpiral spiral;
        private Point centrPoint;
        private Point nextPoint;

        public CircularCloudLayouter(ITagCloudSettings tagCloudSettings, ISpiral spiral)
        {
            centrPoint = new Point(tagCloudSettings.ImageWidth / 2, tagCloudSettings.ImageHeight / 2);
            nextPoint = centrPoint;
            rectangles = new List<Rectangle>();
            this.spiral = spiral;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0)
                throw new ArgumentException(
                    $"Не корректные размеры прямоугольника. Высота: {rectangleSize.Height}, Ширина: {rectangleSize.Width}");

            var currentRectangle = new Rectangle(nextPoint, rectangleSize);

            while (IsIntersects(currentRectangle))
            {
                nextPoint = spiral.CalculatePoint();
                currentRectangle.Location = nextPoint;
            }

            currentRectangle = CorrectLocationRectangle(currentRectangle);

            rectangles.Add(currentRectangle);

            return currentRectangle;
        }

        private bool IsIntersects(Rectangle rectangle)
        {
            return rectangles.Any(rect => rect.IntersectsWith(rectangle));
        }

        private Rectangle CorrectLocationRectangle(Rectangle rectangle)
        {
            rectangle = CorrectCoordXRectangle(rectangle);
            rectangle = CorrectCoordYRectangle(rectangle);
            return rectangle;
        }

        private Rectangle CorrectCoordXRectangle(Rectangle rectangle)
        {
            var oldPoint = rectangle.Location;
            var newPoint = rectangle.Location;

            if (oldPoint.X > centrPoint.X)
            {
                while (!IsIntersects(rectangle) && newPoint.X != centrPoint.X)
                {
                    newPoint.X--;

                    rectangle.Location = newPoint;
                }

                newPoint.X++;
                rectangle.Location = newPoint;
            }
            else if (oldPoint.X < centrPoint.X || newPoint.X != centrPoint.X)
            {
                while (!IsIntersects(rectangle) && newPoint.X != centrPoint.X)
                {
                    newPoint.X++;

                    rectangle.Location = newPoint;
                }

                newPoint.X--;
                rectangle.Location = newPoint;
            }

            return rectangle;
        }

        private Rectangle CorrectCoordYRectangle(Rectangle rectangle)
        {
            var oldPoint = rectangle.Location;
            var newPoint = rectangle.Location;

            if (oldPoint.Y > centrPoint.Y)
            {
                while (!IsIntersects(rectangle) && newPoint.Y != centrPoint.Y)
                {
                    newPoint.Y--;

                    rectangle.Location = newPoint;
                }

                newPoint.Y++;
                rectangle.Location = newPoint;
            }
            else if (oldPoint.Y < centrPoint.Y)
            {
                while (!IsIntersects(rectangle) && newPoint.Y != centrPoint.Y)
                {
                    newPoint.Y++;

                    rectangle.Location = newPoint;
                }

                newPoint.Y--;
                rectangle.Location = newPoint;
            }

            return rectangle;
        }
    }
}