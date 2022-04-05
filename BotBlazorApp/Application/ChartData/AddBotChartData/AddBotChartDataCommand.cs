using BotBlazorApp.Common.Commands;
using BotBlazorApp.Services;

namespace BotBlazorApp.Application.ChartData.AddBotChartData;

public class AddBotChartDataCommand : ICommand
{
    public BotChartData? BotChartData { get; set; }
}