using System;
using System.Net.Sockets;

namespace TestApplication
{
    //public class PipeMessenger : IMessenger, IDisposable
    //{
    //    private NamedPipeServerStream pipeServer;
    //    private NetworkStream pipeStream;
    //    private Queue<string> messages;
    //    public event Action<string> OnGetMessage;
    //    public event Action<string> OnGetConnection;

    //    public PipeMessenger(string name = "testpipe")
    //    {
    //        messages = new Queue<string>();
    //        pipeServer = new NamedPipeServerStream(name, PipeDirection.InOut, 1, PipeTransmissionMode.Message);
    //    }

    //    public async void Send(string message)
    //    {
    //        if (!pipeServer.IsConnected)
    //        {
    //            await pipeServer.WaitForConnectionAsync();
    //            pipeStream = new NetworkStream(pipeServer);
    //        }
    //        try
    //        {
    //            pipeStream.WriteString(message);
    //        }
    //        catch (IOException e)
    //        {
    //            Console.WriteLine("ERROR: {0}", e.Message);
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        pipeServer?.Dispose();
    //    }
    //}
}
