using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CorePush.Apple;
using MDM_Web.API.Helpers;
using MDM_Web.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MDM_Web.API.Controllers
{
    [ApiController]
    [Route("api/enroll")]
    public class EnrollmentController : ControllerBase
    {
        private readonly DeviceRepository _deviceRepository;
        private readonly ApnSender _apnSender;

        public EnrollmentController(DeviceRepository deviceRepository, ApnSettings apnSettings/*, HttpClient httpClient*/)
        {
            _deviceRepository = deviceRepository;

            _apnSender = new ApnSender(apnSettings, new HttpClient());

        }
        
        
        [HttpGet]
        public async Task<ActionResult> Enroll(string deviceID)
        {
            var dev = await _deviceRepository.GetDeviceByID(deviceID);
            if (dev?.deviceToken == null)
            {
                return NotFound();
            }

            var notification = new AppleNotification
            {
                Aps = new AppleNotification.ApsPayload{Alert = "test notification"}
            };
            var apnsResponse = await _apnSender.SendAsync(notification, dev.deviceToken);
            return apnsResponse.IsSuccess ? (ActionResult) Ok() : BadRequest();
        }
    }
}