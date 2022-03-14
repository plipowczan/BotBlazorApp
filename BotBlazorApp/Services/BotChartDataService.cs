using Newtonsoft.Json;

namespace BotBlazorApp.Services;

public class BotChartDataService
{
    private readonly string _botChartDataUrl;

    public BotChartDataService(IConfiguration configuration)
    {
        _botChartDataUrl = configuration["BotChartData:Url"];
    }

    public async Task<BotChartData> GetBotChartDataAsync()
    {
        using var client = new HttpClient();
        using var httpResponseMessage = await client.GetAsync(_botChartDataUrl);

        var data = await httpResponseMessage.Content.ReadAsStringAsync();
        var tempData = data.Replace("data:", "");
        var result = JsonConvert.DeserializeObject<BotChartData>(tempData);
        return result;
    }
}