using System;

namespace Client.Scripts.Communication
{
    public interface IConnector
    {
        event Action<string> Get;
        void Dispose();
    }
}