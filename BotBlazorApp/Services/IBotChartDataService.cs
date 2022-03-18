namespace BotBlazorApp.Services;

public interface IBotChartDataService
{
    Task<BotChartData> GetBotChartDataAsync();
}