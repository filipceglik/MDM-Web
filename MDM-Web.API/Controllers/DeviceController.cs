using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MDM_Web.API.Infrastructure;
using MDM_Web.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace MDM_Web.API.Controllers
{
    [ApiController]
    [Route("api/device")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceRepository _deviceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeviceController(DeviceRepository deviceRepository, IHttpContextAccessor httpContextAccessor)
        {
            _deviceRepository = deviceRepository;
            _httpContextAccessor = httpContextAccessor;
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
        
        [Authorize]
        [HttpGet("index")]
        public async Task<ActionResult<ICollection<Device>>> ListAllDevices()
        {
            if (HttpContext.User.IsInRole("Admin"))
            {
                var devices = _deviceRepository.GetAllDevices();
            }
            else
            {
                var devices = _deviceRepository.GetUserDevices(HttpContext.User.Identity.Name);
            }
            return Ok();
        }
        
        [HttpPut("update")]
        public async Task<ActionResult<Device>> PutDeviceToken([FromBody] PutDeviceTokenViewModel putDeviceTokenViewModel)
        {
            Console.WriteLine();
            await _deviceRepository.UpdateDeviceToken(putDeviceTokenViewModel.deviceToken, putDeviceTokenViewModel.deviceID);
            return Ok();
        }

        [HttpPost("battery/state")]
        public async Task<ActionResult> PostBatteryState([FromBody] PostBatteryStateViewModel postBatteryStateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var batteryInfo = new BatteryInfo
            {
                deviceID = postBatteryStateViewModel.DeviceId,
                BatteryState = postBatteryStateViewModel.BatteryState
            };
            
            return await _deviceRepository.UpdateBatteryState(batteryInfo)
                ? (ActionResult) Ok()
                : BadRequest();
        }
        
        [HttpPost("battery/level")]
        public async Task<ActionResult> PostBatteryLevel([FromBody] PostBatteryLevelViewModel postBatteryLevelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var batteryInfo = new BatteryInfo
            {
                deviceID = postBatteryLevelViewModel.DeviceId,
                BatteryLevel = postBatteryLevelViewModel.BatteryLevel
            };

            return await _deviceRepository.UpdateBatteryLevel(batteryInfo)
                ? (ActionResult) Ok()
                : BadRequest();
        }
        
        [HttpPost("info")]
        public async Task<ActionResult> PostDeviceInfo([FromBody] PostDeviceInfoViewModel postDeviceInfoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var deviceInfo = new DeviceInfo
            {
                deviceID = postDeviceInfoViewModel.DeviceId,
                Model = postDeviceInfoViewModel.Model,
                Name = postDeviceInfoViewModel.Name,
                SystemVersion = postDeviceInfoViewModel.SystemVersion,
                SystemName = postDeviceInfoViewModel.SystemName
            };

            return await _deviceRepository.UpdateDeviceInfo(deviceInfo)
                ? (ActionResult) Ok()
                : BadRequest();
        }
    }
}