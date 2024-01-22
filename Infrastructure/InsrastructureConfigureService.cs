using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InsrastructureConfigureService
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {

            services.AddQuartz(o =>
            {
                o.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService(o =>
            {
                o.WaitForJobsToComplete = true;
            });

            services.ConfigureOptions<LoggingBackgroundJobSetup>();
        }
    }

}