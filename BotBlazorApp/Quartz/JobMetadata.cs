#region usings

#pragma warning disable 1591

#endregion

namespace BotBlazorApp.Quartz;

public class JobMetadata
{
    #region Constructors

    public JobMetadata(Guid id, Type jobType, string jobName, string cronExpression)
    {
        JobId = id;
        JobType = jobType;
        JobName = jobName;
        CronExpression = cronExpression;
    }

    #endregion

    #region Properties

    public Guid JobId { get; set; }

    public Type JobType { get; }

    public string JobName { get; }

    public string CronExpression { get; }

    #endregion
}