namespace BotWebApi.Application.Services;

public interface IBotChartDataService
{
    Task<BotChartData> GetBotChartDataAsync();
}