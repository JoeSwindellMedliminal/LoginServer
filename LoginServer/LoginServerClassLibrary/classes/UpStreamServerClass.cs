namespace LCM
{
    public class UpStreamServerClass
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerAddress { get; set; }
        public string Port { get; set; }

        public UpStreamServerClass()
        {
        }

        public UpStreamServerClass(string username, string password, string serverAddress, string port)
        {
            UserName = username;
            Password = password;
            ServerAddress = serverAddress;
            Port = port;
        }
    }
}
