namespace React_and_WebAPI.Models
{
    public interface IPeopleDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
