using Newtonsoft.Json;

namespace BotBlazorApp.Services;

public class BotChartData
{
    [JsonProperty("time")] public DateTime Date { get; set; }

    [JsonProperty("ema")] public decimal EMA { get; set; }

    [JsonProperty("vwap")] public decimal VWAP { get; set; }

    [JsonProperty("lastPrice")] public decimal LastPrice { get; set; }

    [JsonProperty("supertrend")] public double SuperTrend { get; set; }

    [JsonProperty("entryPrice")] public decimal EntryPrice { get; set; }

    [JsonProperty("highPrice")] public decimal HighPrice { get; set; }

    [JsonProperty("exitPrice")] public decimal ExitPrice { get; set; }
}