#nullable enable
using System;

namespace Model
{
    public class Device
    {
        public Guid Id { get; set; }
        public string deviceID { get; set; }
        public string? deviceToken { get; set; }
        public string? Owner { get; set; }
        public int BatteryState { get; set; }
        
        public float BatteryLevel { get; set; }
        
        public string Name { get; set; }
        
        public string SystemName { get; set; }
        
        public string SystemVersion { get; set; }
        
        public string Model { get; set; }
        
    }
}