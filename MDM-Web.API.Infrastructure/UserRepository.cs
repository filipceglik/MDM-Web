using System.Threading.Tasks;
using Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MDM_Web.API.Infrastructure
{
    public class UserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<User> GetUser(string username) => await _databaseContext
            .GetCollection<User>()
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.UserName == username);

        
    }
}