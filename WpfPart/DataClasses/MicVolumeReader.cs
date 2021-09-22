using System;
using NAudio.Wave;

namespace TestApplication
{
    public class MicVolumeReader: IDisposable
    {
        public event Action<float> OnGetVolume;
        private WaveInEvent waveIn;

        public MicVolumeReader()
        {
            StartGetMicVolume();
        }

        private void StartGetMicVolume()
        {
            if (WaveIn.DeviceCount == 0)
            {
                Console.WriteLine("Microphones count is 0");
                return;
            }
            waveIn = new WaveInEvent();
            waveIn.DataAvailable += WaveOnDataAvailable;
            waveIn.WaveFormat = new WaveFormat(8000, 1);
            waveIn.StartRecording();
        }

        private void WaveOnDataAvailable(object sender, WaveInEventArgs e)
        {
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);

                float amplitude = sample / 32768f;
                float level = Math.Abs(amplitude);
                OnGetVolume?.Invoke(level);
            }
        }

        public void Dispose()
        {
            waveIn?.StopRecording();
        }
    }
}