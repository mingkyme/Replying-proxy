using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace Replying_proxy_client
{
    public partial class Client_Chatting : Window
    {
        const string SERVER_IP = "127.0.0.1";
        const int PORT = 5518;

        NetworkStream stream;
        public Client_Chatting(string id, string pw)
        {
            InitializeComponent();
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(SERVER_IP, PORT);
            stream = tcpClient.GetStream();
            var sendBytes = Encoding.UTF8.GetBytes(id);
            stream.WriteByte((byte)(sendBytes.Length));
            stream.Write(sendBytes, 0, sendBytes.Length);
        }
    }
}
