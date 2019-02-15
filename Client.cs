using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerTest
{
    class Client
    {
        public string UserName;
        private Game game;
        
        public Client(string name)
        {
            this.UserName = name;
        }

        public void Connect(string ip)
        {

        }
    }
}
