using MediatR;

namespace BotWebApi.Application.ChartData.Queries;

internal class
    BotChartDataQueryHandler : IRequestHandler<BotChartDataQuery, List<BotChartDataResponse>>
{

    public BotChartDataQueryHandler()
    {
    }

    public Task<List<BotChartDataResponse>> Handle(BotChartDataQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}