using Model;

namespace MDM_Web.API.ViewModels
{
    public class PostBatteryStateViewModel
    {
        public string DeviceId { get; set; }
        public int BatteryState { get; set; }
    }
}