using System;

namespace Model
{
    public class Device
    {
        public Guid Id { get; set; }
        public string deviceID { get; set; }
        public string? deviceToken { get; set; }
        
        public int BatteryState { get; set; }
        
        public float BatteryLevel { get; set; }
    }
}