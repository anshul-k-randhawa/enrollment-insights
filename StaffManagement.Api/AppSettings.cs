
namespace StaffManagement.Api
{
    public class AppSettings
    {
        public CosmosDb CosmosDb { get; set; }
        public BearerTokenOptions BearerTokenOptions { get; set; }
    }

    public class BearerTokenOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryInMinutes { get; set; }

        public string AuthKey { get; set; }
    }

    public class CosmosDb
    {
        public string Account { get; set; }

        public string Key { get; set; }

        public string DatabaseName { get; set; }

        public string ContainerName { get; set; }
    }
}
