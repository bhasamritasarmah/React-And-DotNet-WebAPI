namespace React_and_WebAPI.Models
{
    public class PeopleDatabaseSettings : IPeopleDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;
    }
}
