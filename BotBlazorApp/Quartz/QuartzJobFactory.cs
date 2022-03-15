#region usings

using Quartz;
using Quartz.Spi;

#pragma warning disable 1591

#endregion

namespace BotBlazorApp.Quartz;

public class QuartzJobFactory : IJobFactory
{
    #region Fields

    private readonly IServiceProvider _serviceProvider;

    #endregion

    #region Constructors

    public QuartzJobFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    #endregion

    #region Public methods

    public IJob NewJob(TriggerFiredBundle triggerFiredBundle, IScheduler scheduler)
    {
        return (IJob)_serviceProvider.GetRequiredService(triggerFiredBundle.JobDetail.JobType);
    }

    public void ReturnJob(IJob job)
    {
    }

    #endregion
}