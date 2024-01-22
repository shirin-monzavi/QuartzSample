using Microsoft.Extensions.Options;
using Quartz;

namespace Infrastructure
{
    public class LoggingBackgroundJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var jobKey = JobKey.Create(nameof(LoggingBackgroundJob));

            options.AddJob<LoggingBackgroundJob>(b =>
            {
                b.WithIdentity(jobKey);
            })
            .AddTrigger(o =>
            {
                o.ForJob(jobKey).WithSimpleSchedule(s =>
                {
                    s.WithIntervalInSeconds(5).RepeatForever();
                });
            });
        }
    }
}