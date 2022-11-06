﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Levels.Map;

namespace TowerDefense.Client
{
    public class RectangleEnemy
    {
        public Rectangle Rectangle { get; set; }
        public Unit Enemy { get; set; }
    }

    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private HubConnection _connection;
        private bool _towerBuildSelected = false;
        private Map _map;
        private List<Rectangle> _rectangles = new();
        private List<(DoubleAnimationUsingPath, DoubleAnimationUsingPath)> _animations = new();
        private List<Storyboard> storyboards = new();
        
        DispatcherTimer gameTimer = new();

        public UserControl2(HubConnection connection, Map map)
        {
            InitializeComponent();
            _connection = connection;
            _map = map;

            //_map.Path.ForEach(path =>
            //{
            //    var pathRect = new Rectangle
            //    {
            //        Width = 32,
            //        Height = 32,
            //        Fill = new ImageBrush
            //        {
            //            ImageSource = new BitmapImage(new Uri($"pack://application:,,,{_map.PathImageSource}"))
            //        }
            //    };

            //    Canvas.SetLeft(pathRect, path.Y);
            //    Canvas.SetTop(pathRect, path.X);

            //    canvas.Children.Add(pathRect);
            //});

            gameTimer.Tick += delegate (object sender, EventArgs e)
            {
                GameTimerEvent(sender, e);
            };

            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Start();
        }

        private async void GameTimerEvent(object sender, EventArgs e)
        {
            await _connection.InvokeAsync("GameTimerTick");
        }

        private void ActionLoaded(object sender, RoutedEventArgs e)
        {
            _connection.On<Player>("Ticked", async (player) =>
            {
                for (int i = 0; i < player.Enemies.Count; i++)
                {
                    if (player.Enemies[i].X + 32 >= canvas.ActualWidth)
                    {
                        canvas.Children.Remove(_rectangles[i]);
                        _rectangles.RemoveAt(i);
                        await _connection.InvokeAsync("EnemyDied", i);
                    }
                    //else
                    //{
                    //    Canvas.SetLeft(_rectangles[i], player.Enemies[i].X);
                    //    Canvas.SetTop(_rectangles[i], player.Enemies[i].Y);
                    //}
                }
            });

            _connection.On<Unit>("EnemyCreated", (unit) =>
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
                _rectangles.Add(rect);
                canvas.Children.Add(rect);

                Path path = new Path();
                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(0, 96);

                LineSegment segment1 = new LineSegment();
                segment1.Point = new Point(288, 96);
                pathFigure.Segments.Add(segment1);

                LineSegment segment2 = new LineSegment();
                segment2.Point = new Point(288, 288);
                pathFigure.Segments.Add(segment2);

                PathGeometry pathGeometry = new PathGeometry();
                pathGeometry.Figures.Add(pathFigure);

                path.Data = pathGeometry;

                var animX = new DoubleAnimationUsingPath();
                animX.Duration = TimeSpan.FromSeconds(10);
                animX.PathGeometry = pathGeometry;
                animX.Source = PathAnimationSource.X;

                var animY = new DoubleAnimationUsingPath();
                animY.Duration = TimeSpan.FromSeconds(10);
                animY.PathGeometry = pathGeometry;
                animY.Source = PathAnimationSource.Y;

                _animations.Add((animX, animY));

                Storyboard storyboard = new Storyboard();


                Storyboard.SetTarget(animX, rect);
                Storyboard.SetTargetProperty(animX, new PropertyPath(Canvas.LeftProperty));
                Storyboard.SetTarget(animY, rect);
                Storyboard.SetTargetProperty(animY, new PropertyPath(Canvas.TopProperty));

                storyboard.Children.Add(animX);
                storyboard.Children.Add(animY);
                storyboards.Add(storyboard);

                storyboard.Begin();
                //rect.BeginAnimation(Canvas.LeftProperty, animX);
                //rect.BeginAnimation(Canvas.TopProperty, animY);

            });

            _connection.On<Unit, int, int>("TowerBuilt", (unit, x, y) =>
            {
                BrushConverter bc = new();

                var tower = new Rectangle
                {
                    Width = 32,
                    Height = 32,
                    Fill = (Brush)bc.ConvertFrom(unit.Color)
                };

                Canvas.SetLeft(tower, x);
                Canvas.SetTop(tower, y);

                canvas.Children.Add(tower);
            });


            _connection.On("PoweredUp", () =>
            {
                storyboards[0].SetSpeedRatio(2);

                //_animations[0].Item1.SpeedRatio += 1;
                //_animations[0].Item2.SpeedRatio += 1;
                ////_rectangles[0].BeginAnimation(, _animations[0].Item1);
                //_rectangles[0].BeginAnimation(Canvas.TopProperty, _animations[0].Item2);

            });
        }
        private async void Create_Shooting_Enemy_Button_Click(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("CreateEnemy", "S");
        }
        private async void Create_Healing_Enemy_Button_Click(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("CreateEnemy", "H");
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("ChangeLevel");
        }

        private void TowerButton_Click(object sender, RoutedEventArgs e)
        {
            _towerBuildSelected = true;
        }

        private async void Canvas_Click(object sender, MouseButtonEventArgs e)
        {
            if (_towerBuildSelected)
            {
                var point = e.GetPosition(canvas);

                int newX = ((int)point.X / 32) * 32;
                int newY = ((int)point.Y / 32) * 32;
                _towerBuildSelected = false;

                await _connection.InvokeAsync("CreateTower", "S", newX, newY);
            }
        }

        private async void PowerUp_Click(object sender, RoutedEventArgs e)
        {

            await _connection.InvokeAsync("PowerUp");
        }
    }
}
