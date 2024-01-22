using Microsoft.EntityFrameworkCore;

namespace Post.Query.Infrastructure.DataAccess;

public class DataBaseContextFactory
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public DataBaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    {
        _configureDbContext = configureDbContext;
    }

    public DataBaseContext CreateDbContext()
    {
        DbContextOptionsBuilder<DataBaseContext> options = new();
        _configureDbContext(options);

        return new DataBaseContext(options.Options);
    }
}