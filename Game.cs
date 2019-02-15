using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Timers = System.Timers;
using System.Windows.Threading;

namespace MultiplayerTest
{
    class Game
    {
        public static GamePage page;
        public static List<Player> players = new List<Player>();
        private int elapsedFrames = 0;

        public void SpawnCharacter()
        {
            Rectangle x = new Rectangle();
            x.Width = 100;
            x.Height = 100;
            x.StrokeThickness = 2;
            x.Fill = new SolidColorBrush(Colors.Black);
            x.Stroke = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(x, 100);
            Canvas.SetBottom(x, 100);
            page.MainCanvas.Children.Add(x);
            players.Add(new Player() { Name = "Bob", Avatar = x});
        }
        public void EnableGame()
        {
            Thread gameThread = new Thread(GameThread);
            gameThread.Start();
        }

        public void GameThread()
        {
            Timers.Timer timer = new Timers.Timer(16);
            timer.Enabled = true;
            timer.Elapsed += new Timers.ElapsedEventHandler(TimerTick);
            timer.Start();

            while (true)
            {
                if (elapsedFrames > 0)
                {
                    elapsedFrames--;
                    //
                    Player player = players[0];
                    player.Position += new Vector(1,1);
                    page.Dispatcher.Invoke(() => 
                    {
                        Canvas.SetLeft(player.Avatar, player.Position.x);
                    });
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            elapsedFrames++;
            Debug.WriteLine(elapsedFrames);
        }

        private void QuitGame()
        {
            Environment.Exit(1);
        }
    }

    class Player
    {
        public string Name;
        public Rectangle Avatar;
        public Vector Position;

        ~Player()
        {
            Game.players.Remove(this);
        }
    }

    struct Vector
    {
        public float x, y;

        public static Vector Zero()
        {
            return new Vector(0,0);
        }
        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
    }
}
