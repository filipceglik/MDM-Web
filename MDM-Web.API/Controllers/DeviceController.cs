using System;
using System.Threading.Tasks;
using MDM_Web.API.Infrastructure;
using MDM_Web.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace MDM_Web.API.Controllers
{
    [ApiController]
    [Route("api/device")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceRepository _deviceRepository;

        public DeviceController(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<Device>> GetDevice(string deviceID)
        {
            var dev = await _deviceRepository.GetDeviceByID(deviceID);
            if (dev != null) return Ok(dev.Id);
            var newDevice = new Device
            {
                deviceID = deviceID,
                Id = Guid.NewGuid(),
            };
            await _deviceRepository.CreateDevice(newDevice);
            dev = await _deviceRepository.GetDeviceByID(deviceID);
            return Ok(dev.Id);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Device>> PutDeviceToken([FromBody] PutDeviceTokenViewModel putDeviceTokenViewModel)
        {
            Console.WriteLine();
            await _deviceRepository.UpdateDeviceToken(putDeviceTokenViewModel.deviceToken, putDeviceTokenViewModel.deviceID);
            return Ok();
        }
    }
}