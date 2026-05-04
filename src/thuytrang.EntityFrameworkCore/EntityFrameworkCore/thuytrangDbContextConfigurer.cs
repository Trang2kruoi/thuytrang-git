using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace thuytrang.EntityFrameworkCore
{
    public static class thuytrangDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<thuytrangDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<thuytrangDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
