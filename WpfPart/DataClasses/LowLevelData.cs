using System;
using System.Collections.Generic;
using System.Linq;
using OpenHardwareMonitor.Hardware;

namespace TestApplication
{
    public class LowLevelData: IDisposable
    {
        private readonly Computer computer;
        private readonly List<ISensor> cpuTempSensors;
        public LowLevelData()
        {
            var updateVisitor = new UpdateVisitor();
            computer = new Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.Accept(updateVisitor);
            cpuTempSensors = computer.Hardware
                .Where(hardware => hardware.HardwareType == HardwareType.CPU)
                .SelectMany(hardware => hardware.Sensors)
                .Where(sensor => sensor.SensorType == SensorType.Temperature)
                .ToList();         
        }

        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }

        private void UpdateSensors()
        {
            cpuTempSensors.ForEach(sensor => sensor.Hardware.Update());
        }

        public float GetAverageCPUTemperature()
        {
            UpdateSensors();
            return cpuTempSensors
                .Where(sensor => sensor.Value.HasValue)
                .Select(sensor => sensor.Value.Value)
                .Average();
        }

        public void Dispose()
        {
            computer?.Close();
        }
    }
}