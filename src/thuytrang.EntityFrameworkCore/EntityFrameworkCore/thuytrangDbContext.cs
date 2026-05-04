using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using thuytrang.Authorization.Roles;
using thuytrang.Authorization.Users;
using thuytrang.MultiTenancy;
using thuytrang.Reviews;

public class thuytrangDbContext : AbpZeroDbContext<Tenant, Role, User, thuytrangDbContext>
{
    // Thêm dòng này
    public virtual DbSet<Review> Reviews { get; set; }

    public thuytrangDbContext(DbContextOptions<thuytrangDbContext> options)
        : base(options)
    {
    }
}