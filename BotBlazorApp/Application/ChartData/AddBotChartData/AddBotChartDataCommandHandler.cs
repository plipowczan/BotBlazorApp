using AutoMapper;
using BotBlazorApp.Common.Commands;
using BotBlazorApp.Data;
using BotBlazorApp.Services;

namespace BotBlazorApp.Application.ChartData.AddBotChartData;

internal class AddBotChartDataCommandHandler : ICommandHandler<AddBotChartDataCommand>
{
    private readonly ILogger<AddBotChartDataCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddBotChartDataCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
        ILogger<AddBotChartDataCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task HandleAsync(AddBotChartDataCommand request)
    {
        if (request.BotChartData != null)
        {
            var botChartDataEntity = _mapper.Map<BotChartDataEntity>(request.BotChartData);
            _unitOfWork.BotChartDataRepository.Insert(botChartDataEntity);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Saved chart data to database");
        }
    }
}