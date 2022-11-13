using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Client
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private readonly List<MovePoint> _path;
        private HubConnection _connection;
        private bool _towerBuildSelected = false;
        private List<Rectangle> _myRectangles = new();
        private List<Rectangle> _enemyRectangles = new();
        private List<Rectangle> _towers = new();
        private List<(DoubleAnimationUsingPath, DoubleAnimationUsingPath)> _animations = new();
        private List<Storyboard> storyboards = new();
        private bool _nextEnemyAoeResistant = false;
        private List<List<Unit>> _enteredEnemies = new();
        private List<List<Rectangle>> _enteredEnemyRects = new();
        private List<int> _survivedEnemies = new();

        DispatcherTimer gameTimer = new();

        public UserControl2(HubConnection connection, List<MovePoint> path, List<MovePoint> tiles)
        {
            InitializeComponent();
            _connection = connection;
            _path = path;

            foreach (var item in tiles)
            {
                var rect = new Rectangle
                {
                    Height = 32,
                    Width = 32,
                    Fill = Brushes.White
                };

                var rect1 = new Rectangle
                {
                    Height = 32,
                    Width = 32,
                    Fill = Brushes.White
                };

                Canvas.SetLeft(rect, item.X);
                Canvas.SetTop(rect, item.Y);


                Canvas.SetLeft(rect1, item.X);
                Canvas.SetTop(rect1, item.Y);

                canvas.Children.Add(rect);
                enemyCanvas.Children.Add(rect1);
            }


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
            _connection.On<List<Unit>, List<Tower>, Player, string>("Ticked", async (enemies, towers, player, contextId) =>
            {
                _enteredEnemyRects = new();
                _enteredEnemies = new();
                _survivedEnemies = new();

                _towers.ForEach(t => 
                {
                    _enteredEnemyRects.Add(new List<Rectangle>());
                });

                _towers.ForEach(t =>
                {
                    _enteredEnemies.Add(new List<Unit>());
                });

                for (int i = 0; i < _myRectangles.Count; i++)
                {
                    double x = Canvas.GetLeft(_myRectangles[i]);
                    double y = Canvas.GetTop(_myRectangles[i]);

                    if (x == 320 && y == 320)
                    {
                        await _connection.InvokeAsync("EnemySurvived", i);
                    }

                    for (int j = 0; j < _towers.Count; j++)
                    {
                        double towerX = Canvas.GetLeft(_towers[j]);
                        double towerY = Canvas.GetTop(_towers[j]);

                        var actualDistance = Math.Sqrt(Math.Pow(x - towerX, 2) + Math.Pow(y - towerY, 2));
                        coordinate.Content = actualDistance.ToString();

                        if (actualDistance < 128)
                        {
                            _enteredEnemyRects[j].Add(_myRectangles[i]);
                            _enteredEnemies[j].Add(enemies[i]);
                            player.Towers[j].EnemiesInRange.Add(enemies[i]);
                        }
                    }
                }

                for (int j = 0; j < _towers.Count; j++)
                {
                    if(_enteredEnemyRects[j].Count > 0)
                    {
                        foreach (var item in canvas.Children.OfType<Line>())
                        {
                            canvas.Children.Remove(item);
                        }

                        Line l = new Line();
                        l.Stroke = new SolidColorBrush(Colors.Red);
                        l.StrokeThickness = 2.0;
                        l.StrokeDashArray = new DoubleCollection(new[] { 5.0 });

                        if (towers[j].isFirstStyle)
                        {
                            towers[j]._shootingStyle = new FirstEnteredRangeShootingStyle();
                        }
                        else
                        {
                            towers[j]._shootingStyle = new HighestEnteredEnemyHealthShootingStyle();
                        }

                        var enemyToShootIndex = towers[j]._shootingStyle.GetEnemyToShoot(player, j);

                        l.X1 = Canvas.GetLeft(_enteredEnemyRects[j][enemyToShootIndex]) + _enteredEnemyRects[j][enemyToShootIndex].Width / 2;
                        l.X2 = Canvas.GetLeft(_towers[j]) + _towers[j].Width / 2;
                        l.Y1 = Canvas.GetTop(_enteredEnemyRects[j][enemyToShootIndex]) + _enteredEnemyRects[j][enemyToShootIndex].Height / 2;
                        l.Y2 = Canvas.GetTop(_towers[j]) + _towers[j].Height / 2;
                        canvas.Children.Add(l);
                        await _connection.InvokeAsync("DrawBulletForEnemy", l.X1, l.X2, l.Y1, l.Y2);

                        await _connection.InvokeAsync("NearTower", _myRectangles.IndexOf(_enteredEnemyRects[j][enemyToShootIndex]), j, _connection.ConnectionId);
                    }
                }      
            });

            _connection.On<int, string>("EnemyDeath", (index, connectionId) =>
            {
                if(_connection.ConnectionId == connectionId)
                {
                    canvas.Children.Remove(_myRectangles[index]);
                    _myRectangles.RemoveAt(index);
                    //_enteredEnemyRects.RemoveAt(0);
                    //_enteredEnemies.RemoveAt(0);
                    //player.Towers[0].EnemiesInRange.Remove(enemies[0]);
                }
                else
                {
                    enemyCanvas.Children.Remove(_enemyRectangles[index]);
                    _enemyRectangles.RemoveAt(index);
                    //_enteredEnemyRects.RemoveAt(0);
                    //_enteredEnemies.RemoveAt(0);
                }
            });

            _connection.On<int, string>("EnemySurvived", (index, connectionId) =>
            {
                if (_connection.ConnectionId == connectionId)
                {
                    canvas.Children.Remove(_myRectangles[index]);
                    _myRectangles.RemoveAt(index);

                }
                else
                {
                    enemyCanvas.Children.Remove(_enemyRectangles[index]);
                    _enemyRectangles.RemoveAt(index);
                }
            });

            _connection.On<double, double, double, double>("DrawBullet", (x1, x2, y1, y2) =>
            {
                //foreach (var item in enemyCanvas.Children.OfType<Line>())
                //{
                //    enemyCanvas.Children.Remove(item);
                //}

                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.Green);
                l.StrokeThickness = 2.0;
                l.StrokeDashArray = new DoubleCollection(new[] { 5.0 });

                l.X1 = x1;
                l.X2 = x2;
                l.Y1 = y1;
                l.Y2 = y2;

                enemyCanvas.Children.Add(l);
            });

            _connection.On<Unit, Player, string>("EnemyCreated", (unit, player, contextId) =>
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
                
                if (player.ConnectionId == contextId) 
                {
                    _enemyRectangles.Add(rect);
                    enemyCanvas.Children.Add(rect);
                }
                else
                {
                    _myRectangles.Add(rect);
                    canvas.Children.Add(rect);
                }

                Path path = new Path();
                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(_path[0].X, _path[0].Y);

                for (int i = 1; i < _path.Count; i++)
                {
                    LineSegment segment = new LineSegment();
                    segment.Point = new Point(_path[i].X, _path[i].Y);
                    pathFigure.Segments.Add(segment);
                }

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
            });

            _connection.On<Unit, Player, string, int, int>("TowerBuilt", (unit, player, contextId, x, y) =>
            {
                BrushConverter bc = new();

                var tower = new Rectangle
                {
                    Width = 32,
                    Height = 32,
                    Fill = Brushes.Black
                };

                Canvas.SetLeft(tower, x);
                Canvas.SetTop(tower, y);

                if (player.ConnectionId == contextId)
                {
                    enemyCanvas.Children.Add(tower);
                }
                else
                {
                    _towers.Add(tower);
                    canvas.Children.Add(tower);
                }
            });


            _connection.On("PoweredUp", () =>
            {
                foreach (var item in storyboards)
                {
                    item.SetSpeedRatio(item.SpeedRatio += 0.1);
                }
            });
        }
        private async void Create_Shooting_Enemy_Button_Click(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("CreateEnemy", "S", _nextEnemyAoeResistant);
            _nextEnemyAoeResistant = false;
        }
        private async void Create_Healing_Enemy_Button_Click(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("CreateEnemy", "H", _nextEnemyAoeResistant);
            _nextEnemyAoeResistant = false;
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

        private void aoe_resistance_button_Click(object sender, RoutedEventArgs e)
        {
            _nextEnemyAoeResistant = true;
        }
    }
}
