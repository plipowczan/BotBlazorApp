using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotBlazorApp.Data;

[Table("BotChartData")]
public class BotChartDataEntity
{
    [Key] public int Id { get; set; }

    public long TimeStamp { get; set; }

    public DateTime Date { get; set; }

    public decimal EMA200 { get; set; }

    public decimal LastPrice { get; set; }

    public decimal? EntryPrice { get; set; }

    public decimal? HighPrice { get; set; }

    public decimal? ExitPrice { get; set; }

    public decimal? EmaInUp { get; set; }

    public decimal? EmaInDown { get; set; }

    public decimal? EmaOutUp { get; set; }

    public decimal? EmaOutDown { get; set; }
}