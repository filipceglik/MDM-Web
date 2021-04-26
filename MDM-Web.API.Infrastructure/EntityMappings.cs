using System.Net.Mime;
using Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MDM_Web.API.Infrastructure
{
    public class EntityMappings
    {
        public static void Map()
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            
            BsonClassMap.RegisterClassMap<Device>(x =>
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
            });
        }
    }
}