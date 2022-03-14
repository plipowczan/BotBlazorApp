using MediatR;

namespace BotWebApi.Application.ChartData.Queries
{
    public class BotChartDataQuery : IRequest<BotChartDataResponse>, IRequest<List<BotChartDataResponse>>
    {
    }
}
