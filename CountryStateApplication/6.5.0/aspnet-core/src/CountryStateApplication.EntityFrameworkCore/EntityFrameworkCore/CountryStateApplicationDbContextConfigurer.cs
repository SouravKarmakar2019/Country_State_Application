using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CountryStateApplication.EntityFrameworkCore
{
    public static class CountryStateApplicationDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CountryStateApplicationDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CountryStateApplicationDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
