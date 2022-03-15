using BotBlazorApp.Data.Repositories;

namespace BotBlazorApp.Data;

public interface IUnitOfWork
{
    GenericRepository<BotChartDataEntity> BotChartDataRepository { get; }
    Task SaveAsync();
    void Save();
}