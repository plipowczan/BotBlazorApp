using BotBlazorApp.Data.Repositories;

namespace BotBlazorApp.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlDbContext _sqlDbContext;

    private GenericRepository<BotChartDataEntity>? _botChartDataRepository;

    public UnitOfWork(SqlDbContext sqlDbContext)
    {
        _sqlDbContext = sqlDbContext;
    }

    public GenericRepository<BotChartDataEntity> BotChartDataRepository
    {
        get
        {
            _botChartDataRepository ??= new GenericRepository<BotChartDataEntity>(_sqlDbContext);
            return _botChartDataRepository;
        }
    }

    public Task SaveAsync()
    {
        return _sqlDbContext.SaveChangesAsync();
    }

    public void Save()
    {
        _sqlDbContext.SaveChanges();
    }
}