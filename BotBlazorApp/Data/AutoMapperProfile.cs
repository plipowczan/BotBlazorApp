using AutoMapper;
using BotBlazorApp.Services;

namespace BotBlazorApp.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BotChartData, BotChartDataEntity>();
    }
}