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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace MultiplayerTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool ValidIP(string ipText)
        {
            string[] ipBytes = ipText.Split('.');
            if(ipBytes.Count() == 4)
            {
                foreach (string ipByte in ipBytes)
                {
                    if (!byte.TryParse(ipByte, out byte byteResult))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidIP(IPTextBox.Text))
            {
                OpenGame();
                Client client = new Client(NameTextBox.Text);
                client.Connect(IPTextBox.Text);
            }
            else
            {
                MessageBox.Show("Invalid ip");
            }
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {
            OpenGame();
            Server server = new Server(NameTextBox.Text);
            server.CreateGame();
            server.OpenLobby();
        }

        private void OpenGame()
        {
            Window gamePage = new GamePage();
            gamePage.Show();
            this.Close();
        }
    }
}
