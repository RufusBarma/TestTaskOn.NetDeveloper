using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Client.Scripts.Communication
{
    public class TcpConnect : IConnector, IDisposable
    {
        private TcpClient client;
        public event Action<string> Get;
        const int port = 9999;
        const string address = "127.0.0.1";
        private bool isDisposed = false;

        public TcpConnect()
        {
            InitConnect();
        }

        private async void InitConnect()
        {
            Debug.Log("Try connect");
            await WaitForConnection();
            WaitMessage();
        }

        private Task WaitForConnection()
        {
            var task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        client = new TcpClient(address, port);
                        Debug.Log("Connected. Wait for messages");
                        break;
                    }
                    catch
                    {
                        // ignored
                        Debug.Log("Can't connect. Try again in 10 seconds");
                        Thread.Sleep(10 * 1000); //wait 10 seconds and try again
                    }
                }
            });
            task.Start();
            return task;
        }

        private async void WaitMessage()
        {
            while (client.Connected)
            {
                NetworkStream stream = null;
                try
                {
                    stream = client.GetStream();
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex.Message);
                    break;
                }
                var message = await GetMessage(stream);
                if (message == null) break;
                Get?.Invoke(message);
            }
            Debug.Log("Disconnected");
            if (!isDisposed)
                InitConnect();
        }

        private Task<string> GetMessage(NetworkStream stream)
        {
            var task = new Task<string>(() =>
            {
                while (!stream.DataAvailable)
                {
                    Thread.Sleep(35);
                    if (!client.Connected)
                        return null;
                    try
                    {
                        stream.Write(new byte[1], 0, 1);                    
                    }
                    catch (IOException e)
                    {
                        Debug.Log(e.Message);
                        return null;
                    }
                }
                
                var data = new byte[1024];
                var builder = new StringBuilder();
                do
                {
                    var bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (stream.DataAvailable);

                var message = builder.ToString();
                builder.Clear();
                return message;
            });
		    task.Start();
		    return task;
        }

        ~TcpConnect()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                client?.Dispose();
                isDisposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}