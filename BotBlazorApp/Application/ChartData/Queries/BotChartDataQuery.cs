using MediatR;

namespace BotBlazorApp.Application.ChartData.Queries
{
    public class BotChartDataQuery : IRequest<BotChartDataResponse>, IRequest<List<BotChartDataResponse>>
    {
    }
}
