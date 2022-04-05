using AutoMapper;
using BotBlazorApp.Common.Commands;
using BotBlazorApp.Data;
using BotBlazorApp.Services;

namespace BotBlazorApp.Application.ChartData.GetAndAddBotChartData;

internal class GetAndAddBotChartDataCommandHandler : ICommandHandler<GetAndAddBotChartDataCommand>
{
    private readonly IBotChartDataService _botChartDataService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAndAddBotChartDataCommandHandler> _logger;

    public GetAndAddBotChartDataCommandHandler(IBotChartDataService botChartDataService, IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetAndAddBotChartDataCommandHandler> logger)
    {
        _botChartDataService = botChartDataService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public static BotChartData? LastBotChartData { get; set; }

    public async Task HandleAsync(GetAndAddBotChartDataCommand request)
    {
        BotChartData? botChartData = null;
        try
        {
            botChartData = await _botChartDataService.GetBotChartDataAsync();
            LastBotChartData = botChartData;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting data from server");
        }

        if (botChartData != null)
        {
            var botChartDataEntity = _mapper.Map<BotChartDataEntity>(botChartData);
            _unitOfWork.BotChartDataRepository.Insert(botChartDataEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}