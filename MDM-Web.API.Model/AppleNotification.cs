using Newtonsoft.Json;

namespace MDM_Web.API.Helpers
{
    public class AppleNotification
    {
        public class ApsPayload
        {
            [JsonProperty("alert")]
            public string Alert { get; set; }

            [JsonProperty("content-available")] 
            public int ContentAvailable = 1;
        }

        // Your custom properties as needed

        [JsonProperty("aps")]
        public ApsPayload Aps { get; set; }
    }
}