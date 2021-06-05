using System;
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
        
        public async Task<bool> UpdateBatteryState(string deviceID, int batteryState)
        {
            var entity = await GetDeviceByID(deviceID);
            if (entity == null)
            {
                return false;
            }
            
            var filter = Builders<Model.Device>.Filter.Eq("deviceID", deviceID);
            var update = Builders<Device>.Update.Set("BatteryState", batteryState);
            await _databaseContext
                .GetCollection<Device>()
                .UpdateOneAsync(filter,update);
            
            return true;
        }
        
        public async Task<bool> UpdateBatteryLevel(string deviceID, float batteryLevel)
        {
            var entity = await GetDeviceByID(deviceID);
            if (entity == null)
            {
                return false;
            }
            
            var filter = Builders<Model.Device>.Filter.Eq("deviceID", deviceID);
            var update = Builders<Device>.Update.Set("BatteryLevel", batteryLevel);
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
    }
}