using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Input = System.Windows.Input;

namespace MultiplayerTest
{
    public partial class GamePage : Window
    {
        public static List<Key> pressedKeys = new List<Key>();
        public GamePage()
        {
            Game.page = this;
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key k = new Key(e.Key);
            pressedKeys.Add(k);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(pressedKeys.Find(x => x.ID == e.Key));
        }

        public static bool Pressed(System.Windows.Input.Key key)
        {
            if (pressedKeys.Find(x => x.ID == key).Equals(default(Key)))
            {
                return false;
            }
            return true;
        }
    }

    public struct Key
    {
        public System.Windows.Input.Key ID;
        public KeyStatus keyStatus;

        public Key(System.Windows.Input.Key id, KeyStatus keyStatus = KeyStatus.began)
        {
            this.ID = id;
            this.keyStatus = keyStatus;
        }
    }

    public enum KeyID
    {
        w,
        s,
        a,
        d,
        space
    }

    public enum KeyStatus
    {
        began,
        pressed,
        ended
    }
}
