using Newtonsoft.Json;

namespace BotBlazorApp.Services;

public class BotChartData
{
    [JsonProperty("timeStamp")] public long TimeStamp { get; set; }

    [JsonProperty("dateTime")] public DateTime Date { get; set; }

    [JsonProperty("ema200")] public decimal EMA200 { get; set; }

    [JsonProperty("lastPrice")] public decimal LastPrice { get; set; }

    [JsonProperty("entryPrice")] public decimal? EntryPrice { get; set; }

    [JsonProperty("highPrice")] public decimal? HighPrice { get; set; }

    [JsonProperty("exitPrice")] public decimal? ExitPrice { get; set; }

    [JsonProperty("emaInUp")] public decimal? EmaInUp { get; set; }

    [JsonProperty("emaInDown")] public decimal? EmaInDown { get; set; }

    [JsonProperty("emaOutUp")] public decimal? EmaOutUp { get; set; }

    [JsonProperty("emaOutDown")] public decimal? EmaOutDown { get; set; }
}
