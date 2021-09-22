using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Threading.Tasks;
using TestApplication.YandexForecastResponse;
using System.Text.Json;
using System.Diagnostics;

namespace TestApplication
{
    public class DataHolder
    {
        private PerformanceCounter RamCounter;
        private PerformanceCounter CPUCounter;
        private LowLevelData lowLevelData;
        private MicVolumeReader micVolumeReader;
        public float CPUPerformance => CPUCounter.NextValue();
        public float CPUTemperature => lowLevelData.GetAverageCPUTemperature();
        public float RamAvailable => RamCounter.NextValue();
        public float MicVolumePer { get; private set; } = 0;
        public List<WebCamData> WebCamObjects { get; }
        public List<MonitorData> MonitorObjects { get; }
        public List<SoundCardData> SoundCardObjects { get; }

        public DataHolder()
        {
            lowLevelData = new LowLevelData();
            CPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            RamCounter = new PerformanceCounter("Memory", "Available MBytes");
            micVolumeReader = new MicVolumeReader();
            micVolumeReader.OnGetVolume += volume => MicVolumePer = volume; 
            WebCamObjects = GetWebCams().ToList();
            MonitorObjects = GetMonitors().ToList();
            SoundCardObjects = GetSoundCards().ToList();
        }
        private IEnumerable<SoundCardData> GetSoundCards()
        {
            var managementObjects = GetFromCimv2(@"SELECT * FROM Win32_SoundDevice");

            foreach (var mo in managementObjects)
                yield return new SoundCardData(mo);
        }

        private IEnumerable<MonitorData> GetMonitors()
        {
            var managementObjects = GetFromCimv2(@"SELECT * FROM Win32_DesktopMonitor");

            foreach (var mo in managementObjects)
                yield return new MonitorData(mo);
        }

        private IEnumerable<WebCamData> GetWebCams()
        {
            var managementObjects = GetFromCimv2(@"SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')");

            foreach (var mo in managementObjects)            
                yield return new WebCamData(mo);            
        }

        private ManagementObjectCollection GetFromCimv2(string query)
        {
            var Namespace = @"root\cimv2";
            var result = new ManagementObjectSearcher(Namespace, query);

            return result.Get();
        }

        public static async Task<ForecastResponse> GetForecast()
        {
            var apiRequest = @"
                https://api.weather.yandex.ru/v2/forecast?
                lat= 55
                & lon= 61
                & lang=ru_RU
                & limit=7
                & hours=false
                & extra=false
                ";
            var client = new HttpClient();
            var yandexApiKey = "enterYourYandexWeatherApiKey";
            if (yandexApiKey == "enterYourYandexWeatherApiKey")
                throw new Exception("Please, enter your yandex weather api key");
            client.DefaultRequestHeaders.Add("X-Yandex-API-Key", yandexApiKey);
            var responseString = await client.GetStringAsync(apiRequest);
            var myDeserializedClass = JsonSerializer.Deserialize<ForecastResponse>(responseString);
            return myDeserializedClass;
        }
    }
}