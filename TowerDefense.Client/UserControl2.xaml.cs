using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using TowerDefense.Server.Models;

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
        HubConnection _connection;

        private readonly List<(double, double)> path = new List<(double, double)>()
            {
                (96, 32),
                (96, 64),
                (96, 96),
                (96, 128),
                (96, 160),
                (96, 192),
                (96, 224),
                (96, 256),
                (96, 288),
                (128, 288),
                (160, 288),
                (192, 288),
                (224, 288),
                (224, 320),
                (224, 352),
                (224, 384),
                (224, 416),
                (224, 448),
                (224, 480),
                (224, 512),
                (224, 544),
                (224, 576),
                (256, 576),
                (288, 576),
                (320, 576),
                (352, 576),
                (352, 544),
                (352, 512),
                (352, 480),
                (352, 448),
                (352, 416),
                (352, 384),
                (352, 352),
                (352, 320),
                (352, 288),
            };

        DispatcherTimer gameTimer = new();

        public UserControl2(HubConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void GameTimerEvent(object sender, EventArgs e, RectangleWithIndex enemy)
        {
            Canvas.SetTop(enemy.Rectangle, path[enemy.Index].Item1);
            Canvas.SetLeft(enemy.Rectangle, path[enemy.Index].Item2);

            if(enemy.Index < path.Count - 1)
            {
                enemy.Index++;
            }
        }

        private async void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startPoint = e.GetPosition(canvas);

            await _connection.InvokeAsync("Draw", startPoint.X, startPoint.Y);
        }

        private void ActionLoaded(object sender, RoutedEventArgs e)
        {
            _connection.On<double, double, Unit>("TowerBuilt", (x, y, unit) =>
            {
                var rect = new Rectangle
                {
                    Width = 20,
                    Height = 20,
                    Fill = unit.Color == "Red" ? Brushes.Red : unit.Color == "Blue" ? Brushes.Blue : Brushes.Yellow,
                };

                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                TowerName.Text = unit.Name;
                canvas.Children.Add(rect);
            });

            _connection.On<Unit>("EnemyCreated", (unit) =>
            {
                var rect = new Rectangle
                {
                    Width = 32,
                    Height = 32,
                    Fill = new SolidColorBrush(Color.FromRgb(122, 122, 122))
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
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            await _connection.InvokeAsync("BuildTower", random.Next(0, 300), random.Next(0, 300), "S");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await _connection.InvokeAsync("CreateEnemy", "lava");
        }
    }
}
