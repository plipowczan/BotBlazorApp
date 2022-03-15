using Microsoft.EntityFrameworkCore;

namespace BotBlazorApp.Data;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
    {

    }

    public DbSet<BotChartDataEntity>? BotChartDatas { get; set; }
}