using Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels;
using Core.CrossCuttingConcerns.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;

public class MongoDbLogger:LoggerServiceBase
{
    private IConfiguration _configuration;

    public MongoDbLogger()
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
        MongoDbConfiguration? dbConfiguration = configuration.GetSection("SerilogConfigurations:MongoDbConfiguration")
            .Get<MongoDbConfiguration>() ?? throw new Exception("");

        Logger = new LoggerConfiguration().WriteTo.MongoDB(dbConfiguration.ConnectionString, collectionName: dbConfiguration.Collection).CreateLogger();


    }
}
