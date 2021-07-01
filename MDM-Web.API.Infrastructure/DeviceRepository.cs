using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MDM_Web.API.Infrastructure
{
    public class DeviceRepository
    {
        private readonly DatabaseContext _databaseContext;

        public DeviceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<Device> GetDeviceByID(string deviceID) => await _databaseContext
            .GetCollection<Device>()
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.deviceID == deviceID);
        
        public async Task<ICollection<Device>> GetUserDevices(string owner) => await _databaseContext
            .GetCollection<Device>()
            .AsQueryable()
            .Where(x => x.Owner == owner)
            .ToListAsync();
        
        public async Task<ICollection<Device>> GetAllDevices() => await _databaseContext
            .GetCollection<Device>()
            .AsQueryable()
            .ToListAsync();
        
        public async Task<bool> UpdateDeviceToken(string deviceToken, string deviceID)
        {
            var entity = await GetDeviceByID(deviceID);
            if (entity == null)
            {
                return false;
            }
            
            var filter = Builders<Model.Device>.Filter.Eq("deviceID", deviceID);
            var update = Builders<Device>.Update.Set("deviceToken", deviceToken);
            await _databaseContext
                .GetCollection<Device>()
                .UpdateOneAsync(filter,update);
            
            return true;
        }
        
        public async Task<bool> UpdateBatteryState(BatteryInfo batteryInfo)
        {
            var entity = await GetDeviceByID(batteryInfo.deviceID);
            if (entity == null)
            {
                return false;
            }
            
            var filter = Builders<Model.Device>.Filter.Eq("deviceID", batteryInfo.deviceID);
            var update = Builders<Device>.Update.Set("BatteryState", batteryInfo.BatteryState);
            await _databaseContext
                .GetCollection<Device>()
                .UpdateOneAsync(filter,update);
            
            return true;
        }
        
        public async Task<bool> UpdateBatteryLevel(BatteryInfo batteryInfo)
        {
            var entity = await GetDeviceByID(batteryInfo.deviceID);
            if (entity == null)
            {
                return false;
            }
            
            var filter = Builders<Model.Device>.Filter.Eq("deviceID", batteryInfo.deviceID);
            var update = Builders<Device>.Update.Set("BatteryLevel", batteryInfo.BatteryLevel);
            await _databaseContext
                .GetCollection<Device>()
                .UpdateOneAsync(filter,update);
            
            return true;
        }
        
        public async Task<bool> CreateDevice(Device device)
        {
            var existingDevice = await GetDeviceByID(device.deviceID);
            if (existingDevice != null && existingDevice.deviceID == device.deviceID)
            {
                return false;
            }

            await _databaseContext
                .GetCollection<Device>()
                .InsertOneAsync(device);
            return true;
        }
        
        public async Task<bool> UpdateDeviceInfo(DeviceInfo deviceInfo)
        {
            var entity = await GetDeviceByID(deviceInfo.deviceID);
            if (entity == null)
            {
                return false;
            }
            
            var filter = Builders<Model.Device>.Filter.Eq("deviceID", deviceInfo.deviceID);
            var update = Builders<Device>.Update
                .Set("Name", deviceInfo.Name)
                .Set("SystemName", deviceInfo.SystemName)
                .Set("SystemVersion", deviceInfo.SystemVersion)
                .Set("Model", deviceInfo.Model);
            await _databaseContext
                .GetCollection<Device>()
                .UpdateOneAsync(filter,update);
            
            return true;
        }
    }
}