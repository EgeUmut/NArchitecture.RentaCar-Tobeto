using Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels;
using Core.CrossCuttingConcerns.Utilities.IoC;

//using Core.CrossCuttingConcerns.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;

public class MssqlLogger:LoggerServiceBase
{
    private IConfiguration _configuration;

    public MssqlLogger()
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
        MssqlConfiguration logConfiguration = configuration.GetSection("SerilogConfigurations:MssqlConfiguration")
           .Get<MssqlConfiguration>() ?? throw new Exception("");

        MSSqlServerSinkOptions sinkOptions = new()
        { TableName = logConfiguration.TableName, AutoCreateSqlTable = logConfiguration.AutoCreatedSqlTable };

        ColumnOptions columnOptions = new();
        global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(connectionString: logConfiguration.ConnectionString, sinkOptions: sinkOptions, columnOptions: columnOptions).CreateLogger();
        Logger = serilogConfig;
    }
}
