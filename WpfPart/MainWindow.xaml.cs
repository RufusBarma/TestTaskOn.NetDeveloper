using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TestApplication;

namespace TestTask
{
    public partial class MainWindow
    {
        private const string prefix = "TypeName:";

        public MainWindow()
        {
            InitializeComponent();
            Console.SetOut(new ControlWriter(TextBlock));
            IMessenger dataSender = new TcpMessenger();
            Console.WriteLine("Start listening");
            dataSender.OnConnectClient += () =>
            {
                Console.WriteLine("Client connected");
                SendForecast(dataSender);
            };
            dataSender.OnDisconnectClient += () => Console.WriteLine("Disconnect client");
            SendRuntimeData(dataSender, 0.5f);
        }

        private static async void SendForecast(IMessenger dataSender)
        {
            var forecast = await DataHolder.GetForecast();
            var serializeObject = JsonSerializer.Serialize(forecast);
            dataSender.Send(prefix + "(Forecast)" + serializeObject);
        }

        private static async void SendRuntimeData(IMessenger messenger, float cycleDelaySec = 1)
        {
            var dataGetter = new DataHolder();
            while (true)
            {
                var task = new Task(() => Thread.Sleep((int) (cycleDelaySec * 1000)));
                task.Start();
                await task;
                messenger.Send(prefix + "(CPUPerformancePer)" + JsonSerializer.Serialize(dataGetter.CPUPerformance));
                messenger.Send(prefix + "(RamAvailableMB)" + JsonSerializer.Serialize(dataGetter.RamAvailable));
                messenger.Send(prefix + "(CPUTemperature)" + JsonSerializer.Serialize(dataGetter.CPUTemperature));
                messenger.Send(prefix + "(MicValue)" + JsonSerializer.Serialize(dataGetter.MicVolumePer));
                messenger.Send(prefix + "(WebCam)" + JsonSerializer.Serialize(dataGetter.WebCamObjects));
                messenger.Send(prefix + "(Monitor)" + JsonSerializer.Serialize(dataGetter.MonitorObjects));
                messenger.Send(prefix + "(SoundCard)" + JsonSerializer.Serialize(dataGetter.SoundCardObjects));
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}