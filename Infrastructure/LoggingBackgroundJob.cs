using Microsoft.Extensions.Logging;
using Quartz;

namespace Infrastructure;

[DisallowConcurrentExecution]
public class LoggingBackgroundJob : IJob
{
    ILogger<LoggingBackgroundJob> _logger;

    public LoggingBackgroundJob(ILogger<LoggingBackgroundJob> logger)
    {
        _logger= logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Time Now" + DateTime.Now.ToString());
        return Task.CompletedTask;
    }
}
