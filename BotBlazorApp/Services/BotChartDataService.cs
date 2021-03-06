using Newtonsoft.Json;

namespace BotBlazorApp.Services;

public class BotChartDataService : IBotChartDataService
{
    private readonly string _botChartDataUrl;

    public BotChartDataService(IConfiguration configuration)
    {
        _botChartDataUrl = configuration["BotChartData:Url"];
    }

    public async Task<BotChartData?> GetBotChartDataAsync()
    {
        using var client = new HttpClient();
        using var httpResponseMessage = await client.GetAsync(_botChartDataUrl);

        var data = await httpResponseMessage.Content.ReadAsStringAsync();
        var tempData = data.Replace("data:", "").Replace("NaN", "");
        var result = JsonConvert.DeserializeObject<BotChartData>(tempData);
        return result;
    }
}