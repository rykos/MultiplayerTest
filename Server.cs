using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace MultiplayerTest
{
    class Server
    {
        public Server(string hostName)
        {
            this.hostName = hostName;
        }
        private string hostName;
        private TcpListener listener;
        private Game game;

        //Opens lobby for players to join
        public void OpenLobby()
        {

        }

        public void CreateGame()
        {
            this.game = new Game();
        }

        private void StartAcceptingUsers()
        {
            
        }

        private void StopAcceptingUsers()
        {

        }
    }
}
