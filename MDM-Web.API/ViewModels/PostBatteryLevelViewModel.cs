using Model;

namespace MDM_Web.API.ViewModels
{
    public class PostBatteryLevelViewModel
    {
        public string DeviceId { get; set; }
        public float BatteryLevel { get; set; }
    }
}