using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Client
{
    public static class Animation
    {
        public static Rectangle CreateAnimation(Unit unit, List<MovePoint> movePoints, 
            List<(DoubleAnimationUsingPath, DoubleAnimationUsingPath)> animations,
            List<Storyboard> storyboards)
        {
            var rect = new Rectangle
            {
                Width = 32,
                Height = 32,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri($"pack://application:,,,{unit.ImageSource}"))
                }
            };

            Canvas.SetTop(rect, 96);
            Canvas.SetLeft(rect, 0);

            Path path = new Path();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(movePoints[0].X, movePoints[0].Y);

            for (int i = 1; i < movePoints.Count; i++)
            {
                LineSegment segment = new LineSegment();
                segment.Point = new Point(movePoints[i].X, movePoints[i].Y);
                pathFigure.Segments.Add(segment);
            }

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            path.Data = pathGeometry;

            var animX = new DoubleAnimationUsingPath();
            animX.Duration = TimeSpan.FromSeconds(unit.Speed);
            animX.PathGeometry = pathGeometry;
            animX.Source = PathAnimationSource.X;

            var animY = new DoubleAnimationUsingPath();
            animY.Duration = TimeSpan.FromSeconds(unit.Speed);
            animY.PathGeometry = pathGeometry;
            animY.Source = PathAnimationSource.Y;

            animations.Add((animX, animY));

            Storyboard storyboard = new Storyboard();

            Storyboard.SetTarget(animX, rect);
            Storyboard.SetTargetProperty(animX, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTarget(animY, rect);
            Storyboard.SetTargetProperty(animY, new PropertyPath(Canvas.TopProperty));

            storyboard.Children.Add(animX);
            storyboard.Children.Add(animY);

            storyboards.Add(storyboard);

            return rect;
        }
    }
}
