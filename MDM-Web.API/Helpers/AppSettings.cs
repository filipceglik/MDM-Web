namespace MDM_Web.API.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string ValidIssuer { get; set; }
        public int LifetimeInSeconds { get; set; }
    }
}