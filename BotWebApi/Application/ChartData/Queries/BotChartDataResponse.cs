namespace BotWebApi.Application.ChartData.Queries;
public class BotChartDataResponse
{
    public DateTime Time { get; set; }

    public double Ema { get; set; }

    public double Vwap { get; set; }

    public decimal LastPrice { get; set; }

    public double Supertrend { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal HighPrice { get; set; }

    public decimal ExitPrice { get; set; }
}
