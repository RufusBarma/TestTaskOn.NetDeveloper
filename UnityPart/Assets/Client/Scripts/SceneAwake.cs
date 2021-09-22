using System;
using System.Collections.Generic;
using System.Linq;
using Client.Scripts.Communication;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts
{
    public class SceneAwake: MonoBehaviour
    {
        private IConnector dataGetter;
        private IMessageAnalyzer analyzer;

        [SerializeField] private Slider cpuVisual;
        [SerializeField] private Text cpuTemperatureVisual;
        [SerializeField] private Text ramAvailableVisual;
        [SerializeField] private Text forecastVisual;

        [SerializeField] private Text webcamVisual;
        [SerializeField] private Text monitorVisual;
        [SerializeField] private Text soundcardVisual;

        [SerializeField] private Slider micVisual;

        private void Awake()
        {
            
            dataGetter = new TcpConnect();
            analyzer = new MessageAnalyzer(GetCommandList());
            dataGetter.Get += analyzer.Analyze;
        }

        private void OnDestroy()
        {
            dataGetter.Get -= analyzer.Analyze;
            dataGetter.Dispose();
        }

        private Dictionary<string, Action<string>> GetCommandList()
        {
            void GetDeviceInfo<T>(string value, Text field) where T: PnPEntity
            {
                var data = JsonUtility.FromJson<DataContainer<List<T>>>("{\"Data\":" + value + "}");
                field.text = data == null ? "No devices" : "";
                data?.Data?.ForEach(item => { field.text += item.Name + "\n"; });
            }

            return new Dictionary<string, Action<string>>()
            {
                {"CPUPerformancePer", value =>{
                    if (float.TryParse(value.Replace('.',','), out var cpuPer))
                        cpuVisual.value = cpuPer;
                }},
                {"RamAvailableMB", value => ramAvailableVisual.text = value + " MB"},
                {"CPUTemperature", value => {
                    if (float.TryParse(value.Replace('.',','), out var temperature))
                        cpuTemperatureVisual.text = $"{temperature:f1} C"; 
                }},
                {"MicValue", value =>
                {
                    if (float.TryParse(value.Replace('.',','), out var micValue))
                        micVisual.value = micValue * 100;
                }},
                {"WebCam",value => GetDeviceInfo<WebCamData>(value, webcamVisual)},
                {"Monitor", value => GetDeviceInfo<MonitorData>(value, monitorVisual)},
                {"SoundCard",value => GetDeviceInfo<SoundCardData>(value, soundcardVisual)},
                {"Forecast", value =>
                {
                    var myDeserializedClass = JsonUtility.FromJson<ForecastResponse>(value);
                    forecastVisual.text = myDeserializedClass.ToString();
                }}
            };
        }         
        
        [Serializable]
        public class DataContainer<T>
        {
            public T Data;
        }
    }             
}