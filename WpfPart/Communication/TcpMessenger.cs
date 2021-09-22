using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Documents;
using TestApplication.Extensions;

namespace TestApplication
{
    public class TcpMessenger : IMessenger, IDisposable
    {
        private readonly TcpListener server;
        private ConcurrentBag<TcpClient> clients;
        
        public TcpMessenger()
        {
            clients = new ConcurrentBag<TcpClient>();
            server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            WaitForConnection();
        }

        private async void WaitForConnection()
        {
            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                clients.Add(client);
                OnConnectClient?.Invoke();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        public event Action<string> OnGetMessage;
        public event Action OnConnectClient;
        public event Action OnDisconnectClient;

        public void Send(string message)
        {
            clients.ForEach(client => SendMessage(message, client));
        }

        private async void SendMessage(string message, TcpClient client)
        {
            if (!client.Connected)
            {
                client.Close();
                clients.TryTake(out client);
                OnDisconnectClient?.Invoke();
                return;
            }

            try
            {
                var ns = client.GetStream();
                var bytes = Encoding.Unicode.GetBytes(message);
                await ns.WriteAsync(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            server?.Stop();
            foreach (var client in clients)
                client?.Dispose();
        }
    }
}
