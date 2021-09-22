using System;

namespace TestApplication
{
    public interface IMessenger
    {
        event Action<string> OnGetMessage;
        event Action OnConnectClient;
        event Action OnDisconnectClient;
        void Send(string message);
    }
}
