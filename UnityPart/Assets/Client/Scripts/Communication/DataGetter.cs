using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;
using UnityEngine;

namespace Client.Scripts.Communication
{
    public class DataGetter: IConnector, IDisposable
    {
        private NamedPipeClientStream pipeClient;
        public event Action<string> Get;
        
        public void StartClients()
        {
            pipeClient = new NamedPipeClientStream(".", "testpipe",
                PipeDirection.InOut, PipeOptions.None,
                TokenImpersonationLevel.None) {ReadMode = PipeTransmissionMode.Message};

            Debug.Log("Connecting to server...\n");
            pipeClient.Connect();

            var ss = new StreamString(pipeClient);
            // Validate the server's signature string.
            if (ss.ReadString() == "I am the one true server!")
            {
                // The client security token is sent with the first write.
                // Send the name of the file whose contents are returned
                // by the server.
                ss.WriteString("d:\\textfile.txt");

                // Print the file to the screen.
                Debug.Log(ss.ReadString());
            }
            else
            {
                Debug.Log("Server could not be verified.");
            }
            pipeClient.Close();
        }

        public void Dispose()
        {
            pipeClient?.Dispose();
        }
    }
    
    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len = 0;

            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            byte[] inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }
}