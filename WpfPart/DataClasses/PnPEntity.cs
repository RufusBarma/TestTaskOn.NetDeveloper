using System.Management;

namespace TestApplication
{
    public class PnPEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public string PNPDeviceID { get; private set; }
        public string Status { get; private set; }

        public PnPEntity() { }
        public PnPEntity(ManagementBaseObject managementObject)
        {
            Name = managementObject.GetPropertyValue("Name").ToString();
            Description = managementObject.GetPropertyValue("Description").ToString();
            DeviceID = managementObject.GetPropertyValue("DeviceID").ToString();
            PNPDeviceID = managementObject.GetPropertyValue("PNPDeviceID").ToString();
            Status = managementObject.GetPropertyValue("Status").ToString();
        }
    }
    public class WebCamData : PnPEntity
    {
        public WebCamData() { }
        public WebCamData(ManagementBaseObject managementObject) : base(managementObject) { }
    }
    public class MonitorData : PnPEntity
    {
        public MonitorData() { }
        public MonitorData(ManagementBaseObject managementObject) : base(managementObject) { }
    }
    public class SoundCardData : PnPEntity
    {
        public SoundCardData() { }
        public SoundCardData(ManagementBaseObject managementObject) : base(managementObject) { }
    }
}