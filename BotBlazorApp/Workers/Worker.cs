using BotBlazorApp.Application.ChartData.AddBotChartData;
using BotBlazorApp.Common.Commands;
using BotBlazorApp.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace BotBlazorApp.Workers;

public class Worker : BackgroundService
{
    private readonly string _botChartDataUrl;
    private readonly ILogger<Worker> _logger;
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly HubConnection _hubConnection;

    public Worker(ILogger<Worker> logger, IConfiguration configuration, ICommandDispatcher commandDispatcher)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
        _botChartDataUrl = configuration["BotChartData:Url"];
        var appUrl = configuration["App:Url"];

        _hubConnection = new HubConnectionBuilder()
            .WithUrl(appUrl + "/botchartdatahub")
            .Build();

        _hubConnection.StartAsync();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        long lastTimestamp = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            string? responseString = null;
            try
            {
                using var httpClient = new HttpClient();
                var stream = httpClient.GetStreamAsync(_botChartDataUrl, stoppingToken).Result;

                using var reader = new StreamReader(stream);

                responseString = await reader.ReadToEndAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting data from api");
            }
            
            if (string.IsNullOrEmpty(responseString))
                continue;

            BotChartData? botChartData = null;

            try
            {
                var tempData = responseString.Replace("data:", "").Replace("NaN", "");
                botChartData = JsonConvert.DeserializeObject<BotChartData>(tempData);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error deserialize data {responseString}");
            }

            if(botChartData == null)
                continue;

            if (botChartData.TimeStamp != lastTimestamp)
            {
                lastTimestamp = botChartData.TimeStamp;
                await _hubConnection.SendAsync("SendBotChartData", botChartData, cancellationToken: stoppingToken);
                await _commandDispatcher.ExecuteAsync(new AddBotChartDataCommand { BotChartData = botChartData });
            }
            else
            {
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}