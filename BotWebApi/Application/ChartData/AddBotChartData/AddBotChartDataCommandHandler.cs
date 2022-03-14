using BotWebApi.Application.Services;
using MediatR;

namespace BotWebApi.Application.ChartData.AddBotChartData;

internal class AddBotChartDataCommandHandler : IRequestHandler<AddBotChartDataCommand>
{

    private readonly IBotChartDataService _botChartDataService;

    public AddBotChartDataCommandHandler(IBotChartDataService botChartDataService)
    {
        _botChartDataService = botChartDataService;
    }

    public Task<Unit> Handle(AddBotChartDataCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}