using BotBlazorApp.Services;
using Microsoft.AspNetCore.SignalR;

namespace BotBlazorApp.Hubs
{
    public class BotChartDataHub : Hub
    {
        public async Task SendBotChartData(BotChartData botChartData)
        {
            await Clients.All.SendAsync("ReceiveBotChartData", botChartData);
        }
    }
}
