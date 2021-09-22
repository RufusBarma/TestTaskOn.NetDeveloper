using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace TestApplication
{
    internal class Program
    {
        private const string prefix = "TypeName:";
        
        public static void Main(string[] args)
        {
            IMessenger dataSender = new TcpMessenger();
            dataSender.OnConnectClient += () =>
            {
                Console.WriteLine("Client connected");
                SendForecast(dataSender);
            };
            dataSender.OnDisconnectClient += () => Console.WriteLine("Disconnect client");
            SendRuntimeData(dataSender, 0.5f);
            while (Console.ReadLine() != "q")
            {
            }
        }

        private static async void SendForecast(IMessenger dataSender)
        {
            var forecast = await DataHolder.GetForecast();
            var serializeObject = JsonSerializer.Serialize(forecast);
            dataSender.Send(prefix + "(Forecast)" + serializeObject);
        }

        private static Task SendRuntimeData(IMessenger messenger, float cycleDelaySec = 1)
        {    
            var task = new Task(() =>
            {
                var dataGetter = new DataHolder();
                while (true)
                {
                    Thread.Sleep((int)(cycleDelaySec * 1000));
                    messenger.Send(prefix + "(CPUPerformancePer)" + JsonSerializer.Serialize(dataGetter.CPUPerformance));
                    messenger.Send(prefix + "(RamAvailableMB)" + JsonSerializer.Serialize(dataGetter.RamAvailable));
                    messenger.Send(prefix + "(CPUTemperature)" + JsonSerializer.Serialize(dataGetter.CPUTemperature));
                    messenger.Send(prefix + "(MicValue)" + JsonSerializer.Serialize(dataGetter.MicVolumePer));
                    messenger.Send(prefix + "(WebCam)" + JsonSerializer.Serialize(dataGetter.WebCamObjects));
                    messenger.Send(prefix + "(Monitor)" + JsonSerializer.Serialize(dataGetter.MonitorObjects));
                    messenger.Send(prefix + "(SoundCard)" + JsonSerializer.Serialize(dataGetter.SoundCardObjects));
                }
            });
            task.Start();
            return task;
        }
    }
}