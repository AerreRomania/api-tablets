namespace SmartB.API.Models
{
    public class DeviceForUpdate
    {
        public string SN { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
        public bool Active { get; set; }

    }
}
