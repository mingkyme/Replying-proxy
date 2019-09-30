using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Replying_proxy_server
{
    class NamedTcpClient : TcpClient
    {
        private IPAddress ip;
        public IPAddress IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }
        private string name;
        public string NAME
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string receiveName;
        public string ReceiveName
        {
            get
            {
                return receiveName;
            }
            set
            {
                receiveName = value;
            }
        }
        private TcpClient client;
        public TcpClient CLIENT
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
            }
        }
        private NamedTcpClient receiveTcpClient;
        public NamedTcpClient ReceiveTcpClient
        {
            get
            {
                return receiveTcpClient;
            }
            set
            {
                receiveTcpClient = value;
            }
        }
        private NetworkStream stream;
        private BackgroundWorker receiveBackgroundWorker;
        public NamedTcpClient(TcpClient client)
        {
            this.client = client;
            stream = client.GetStream();
            int len = stream.ReadByte();
            byte[] receiveBytes = new byte[len];
            stream.Read(receiveBytes, 0, len);
            this.name = Encoding.UTF8.GetString(receiveBytes);
            this.ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
            receiveBackgroundWorker = new BackgroundWorker();
            receiveBackgroundWorker.DoWork += ReceiveBackgroundWorker_DoWork;
            receiveBackgroundWorker.RunWorkerAsync();
        }

        private void ReceiveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
