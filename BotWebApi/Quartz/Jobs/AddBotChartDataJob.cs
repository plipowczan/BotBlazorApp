#region usings

using BotWebApi.Application.ChartData.AddBotChartData;
using MediatR;
using Quartz;

#endregion

namespace BotWebApi.Quartz.Jobs;

[DisallowConcurrentExecution]
public class AddBotChartDataJob : IJob
{
    private readonly ILogger<AddBotChartDataJob> _logger;

    private readonly IMediator _mediator;

    #region Constructors

    public AddBotChartDataJob(IMediator mediator,
        ILogger<AddBotChartDataJob> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    #endregion

    #region Public methods

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogWarning("AddBotChartDataJob triggered");
        await _mediator.Send(new AddBotChartDataCommand());
    }

    #endregion
}