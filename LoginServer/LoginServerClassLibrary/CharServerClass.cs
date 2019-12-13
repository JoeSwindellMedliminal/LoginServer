using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServerClassLibrary
{
    public class CharServerClass
    {
        private string username;
        private string password;
        private string serverAddress;
        private string port;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerAddress { get; set; }
        public string Port { get; set; }

        public CharServerClass()
        {

        }

        public CharServerClass(string UserName, string Password, string ServerAddress, string Port)
        {
            username = UserName;
            password = Password;
            serverAddress = ServerAddress;
            port = Port;
        }
    }
}