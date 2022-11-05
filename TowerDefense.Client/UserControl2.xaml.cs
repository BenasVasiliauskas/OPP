using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Levels.Map;

namespace TowerDefense.Client
{
    public class RectangleWithIndex
    {
        public Rectangle Rectangle { get; set; }
        public int Index { get; set; }
    }

    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private HubConnection _connection;
        private bool _towerBuildSelected = false;
        private Map _map;
        
        DispatcherTimer gameTimer = new();

        public UserControl2(HubConnection connection, Map map)
        {
            InitializeComponent();
            _connection = connection;
            _map = map;

            _map.Path.ForEach(path =>
            {
                var pathRect = new Rectangle
                {
                    Width = 32,
                    Height = 32,
                    Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri($"pack://application:,,,{_map.PathImageSource}"))
                    }
                };

                Canvas.SetLeft(pathRect, path.Y);
                Canvas.SetTop(pathRect, path.X);

                canvas.Children.Add(pathRect);
            });
        }

        private async void GameTimerEvent(object sender, EventArgs e, RectangleWithIndex enemy)
        {
            await _connection.InvokeAsync("EnemyMoved", _map.Path[enemy.Index].X, _map.Path[enemy.Index].Y);
            Canvas.SetTop(enemy.Rectangle, _map.Path[enemy.Index].X);
            Canvas.SetLeft(enemy.Rectangle, _map.Path[enemy.Index].Y);

            if(enemy.Index < _map.Path.Count - 1)
            {
                enemy.Index++;
            }
        }

        private void ActionLoaded(object sender, RoutedEventArgs e)
        {
            _connection.On<Player>("GameTimerTicked", (unit) => 
            { 
                
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
                Canvas.SetZIndex(rect, 2);

                canvas.Children.Add(rect);

                var rectangleWithIndex = new RectangleWithIndex { Rectangle = rect };

                gameTimer.Tick += delegate (object sender, EventArgs e)
                {
                    GameTimerEvent(sender, e, rectangleWithIndex);
                };

                gameTimer.Interval = TimeSpan.FromMilliseconds(unit.Speed);
                gameTimer.Start();
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

            _connection.On<string>("LevelChanged", (levelName) =>
            {
                TowerName.Text = levelName;
            });
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("CreateEnemy", "S");
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
