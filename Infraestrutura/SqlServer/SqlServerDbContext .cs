using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.SqlServer
{
    public abstract class SqlServerDbContext : DbContext
    {
        protected SqlServerDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
