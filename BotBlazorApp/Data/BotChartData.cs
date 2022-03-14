﻿using Newtonsoft.Json;

namespace BotBlazorApp.Data;

public class BotChartData
{
    [JsonProperty("time")] public DateTime Time { get; set; }

    [JsonProperty("ema")] public double Ema { get; set; }

    [JsonProperty("vwap")] public double Vwap { get; set; }

    [JsonProperty("lastPrice")] public decimal LastPrice { get; set; }

    [JsonProperty("supertrend")] public double Supertrend { get; set; }

    [JsonProperty("entryPrice")] public decimal EntryPrice { get; set; }

    [JsonProperty("highPrice")] public decimal HighPrice { get; set; }

    [JsonProperty("exitPrice")] public decimal ExitPrice { get; set; }
}