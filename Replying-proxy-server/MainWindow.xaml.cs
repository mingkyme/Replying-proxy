using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Replying_proxy_server
{
    public partial class MainWindow : Window
    {

        const int PORT = 5518;
        TcpListener listener;

        BackgroundWorker acceptClient;

        ObservableCollection<NamedTcpClient> clients = new ObservableCollection<NamedTcpClient>();
        public MainWindow()
        {
            InitializeComponent();

            XAML_List.ItemsSource = clients;

            listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();

            acceptClient = new BackgroundWorker();
            acceptClient.DoWork += AcceptClient_DoWork;
            acceptClient.RunWorkerAsync();

            AcceptClient accept = new AcceptClient();
        }
        private void AcceptClient_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var tempClient = listener.AcceptTcpClient();
                Dispatcher.Invoke(() =>
                {
                    clients.Add(new NamedTcpClient(tempClient));

                });
                Console.WriteLine("TEST");

            }
        }
    }
}
