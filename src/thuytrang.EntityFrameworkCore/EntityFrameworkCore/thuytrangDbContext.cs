using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using thuytrang.Authorization.Roles;
using thuytrang.Authorization.Users;
using thuytrang.MultiTenancy;
using thuytrang.Reviews; // Đảm bảo có dòng này để nhận diện class Review

namespace thuytrang.EntityFrameworkCore
{
    public class thuytrangDbContext : AbpZeroDbContext<Tenant, Role, User, thuytrangDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Review> Reviews { get; set; }

        public thuytrangDbContext(DbContextOptions<thuytrangDbContext> options)
            : base(options)
        {
        }
    }
}