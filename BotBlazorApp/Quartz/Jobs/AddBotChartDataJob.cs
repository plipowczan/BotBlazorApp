#region usings

using BotBlazorApp.Application.ChartData.GetAndAddBotChartData;
using BotBlazorApp.Common.Commands;
using Quartz;

#endregion

namespace BotBlazorApp.Quartz.Jobs;

[DisallowConcurrentExecution]
public class AddBotChartDataJob : IJob
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly ILogger<AddBotChartDataJob> _logger;

    #region Constructors

    public AddBotChartDataJob(ILogger<AddBotChartDataJob> logger, ICommandDispatcher commandDispatcher)
    {
        //  _mediator = mediator;
        _logger = logger;
        _commandDispatcher = commandDispatcher;
    }

    #endregion

    #region Public methods

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogWarning("AddBotChartDataJob triggered");
        await _commandDispatcher.ExecuteAsync(new GetAndAddBotChartDataCommand());
    }

    #endregion
}