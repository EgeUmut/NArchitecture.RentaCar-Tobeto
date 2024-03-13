namespace Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels;

public class MssqlConfiguration
{
    public string ConnectionString { get; set; }
    public string TableName { get; set; }
    public bool AutoCreatedSqlTable { get; set; }
}
