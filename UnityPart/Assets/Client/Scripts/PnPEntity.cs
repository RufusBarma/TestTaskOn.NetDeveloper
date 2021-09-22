using System;

namespace Client.Scripts
{
    [Serializable]
    public class PnPEntity
    {
        public string Name;
        public string Description;
        public string DeviceID;
        public string PNPDeviceID;
        public string Status;
        public PnPEntity(){}

        public override string ToString()
        {
            return "Name: " + Name + ". Description: " + Description;
        }
    }

    [Serializable]
    public class WebCamData : PnPEntity
    {
        public override string ToString()
        {
            return "WebCam info: (" + base.ToString() + ").";
        }
    }

    [Serializable]
    public class MonitorData : PnPEntity
    {
        public override string ToString()
        {
            return "Monitor info: (" + base.ToString() + ").";
        }
    }

    [Serializable]
    public class SoundCardData : PnPEntity
    {
        public override string ToString()
        {
            return "SoundCard info: (" + base.ToString() + ").";
        }
    }
}