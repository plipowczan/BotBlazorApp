using AutoMapper;
using BotBlazorApp.Common.Commands;
using BotBlazorApp.Data;
using BotBlazorApp.Services;
using MediatR;

namespace BotBlazorApp.Application.ChartData.AddBotChartData;

internal class AddBotChartDataCommandHandler : ICommandHandler<AddBotChartDataCommand>
{
    private readonly IBotChartDataService _botChartDataService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddBotChartDataCommandHandler(IBotChartDataService botChartDataService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _botChartDataService = botChartDataService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task HandleAsync(AddBotChartDataCommand request)
    {
        try
        {
            var botChartData = await _botChartDataService.GetBotChartDataAsync();

            var botChartDataEntity = _mapper.Map<BotChartDataEntity>(botChartData);
            _unitOfWork.BotChartDataRepository.Insert(botChartDataEntity);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}