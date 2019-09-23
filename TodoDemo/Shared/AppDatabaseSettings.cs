namespace TodoDemo.Shared
{
    public class AppDatabaseSettings : IAppDatabaseSettings
    {
        public string TodosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAppDatabaseSettings
    {
        string TodosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
