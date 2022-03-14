using Newtonsoft.Json;

namespace BotBlazorApp.Data;

public class BotChartDataService
{
    private readonly string _botChartDataUrl;

    public BotChartDataService(IConfiguration configuration)
    {
        _botChartDataUrl = configuration["BotChartData:Url"];
    }

    public async Task<List<BotChartData>> GetBotChartDataAsync()
    {
        using var client = new HttpClient();
        using var httpResponseMessage = await client.GetAsync(_botChartDataUrl);

        var data = await httpResponseMessage.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<BotChartData>>(data);

        throw new NotImplementedException();
    }
}