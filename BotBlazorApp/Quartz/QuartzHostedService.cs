#region usings

using Quartz;
using Quartz.Spi;

#pragma warning disable 1591

#endregion

namespace BotBlazorApp.Quartz;

public class QuartzHostedService : IHostedService
{
    #region Constructors

    public QuartzHostedService(ISchedulerFactory schedulerFactory, IEnumerable<JobMetadata> jobMetadataList,
        IJobFactory jobFactory)
    {
        _schedulerFactory = schedulerFactory;
        _jobMetadataList = jobMetadataList;
        _jobFactory = jobFactory;
    }

    #endregion

    #region Properties

    public IScheduler? Scheduler { get; set; }

    #endregion

    #region Fields

    private readonly ISchedulerFactory _schedulerFactory;

    private readonly IJobFactory _jobFactory;

    private readonly IEnumerable<JobMetadata> _jobMetadataList;

    #endregion

    #region Private methods

    private ITrigger CreateTrigger(JobMetadata newJobMetadata)
    {
        return TriggerBuilder.Create().WithIdentity(newJobMetadata.JobId.ToString()).StartNow()
            .WithCronSchedule(newJobMetadata.CronExpression)
            .WithDescription($"{newJobMetadata.JobName}").Build();
    }

    private IJobDetail CreateJob(JobMetadata newJobMetadata)
    {
        return JobBuilder.Create(newJobMetadata.JobType).WithIdentity(newJobMetadata.JobId.ToString())
            .WithDescription($"{newJobMetadata.JobName}").Build();
    }

    #endregion

    #region Public methods

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        Scheduler.JobFactory = _jobFactory;
        foreach (var jobSchedule in _jobMetadataList)
        {
            var job = CreateJob(jobSchedule);
            var trigger = CreateTrigger(jobSchedule);
            await Scheduler.ScheduleJob(job, trigger, cancellationToken);
        }

        await Scheduler.Start(cancellationToken);
    }

    public Task? StopAsync(CancellationToken cancellationToken)
    {
        return Scheduler?.Shutdown(cancellationToken);
    }

    #endregion
}