using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotBlazorApp.Data;

[Table("BotChartData")]
public class BotChartDataEntity
{
    [Key] public int Id { get; set; }

    public DateTime Date { get; set; }

     public decimal EMA { get; set; }

     public decimal VWAP { get; set; }

     public decimal LastPrice { get; set; }

     public decimal SuperTrend { get; set; }

     public decimal? EntryPrice { get; set; }

     public decimal? HighPrice { get; set; }

     public decimal? ExitPrice { get; set; }
}