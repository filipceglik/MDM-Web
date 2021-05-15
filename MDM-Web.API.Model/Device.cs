using System;

namespace Model
{
    public class Device
    {
        public Guid Id { get; set; }
        public string deviceID { get; set; }
        public byte[]? deviceToken { get; set; }
    }
}