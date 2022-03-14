using MediatR;

namespace BotBlazorApp.Application.ChartData.Queries;

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