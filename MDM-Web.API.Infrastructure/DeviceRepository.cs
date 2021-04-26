using System.Threading.Tasks;
using Model;
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
        
        public async Task<Device> GetDevice(string deviceID) => await _databaseContext
            .GetCollection<Device>()
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.deviceID == deviceID);
        
        public async Task<bool> CreateDevice(Device device)
        {
            var existingDevice = await GetDevice(device.deviceID);
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