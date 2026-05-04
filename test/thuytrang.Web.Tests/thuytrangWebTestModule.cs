using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using thuytrang.EntityFrameworkCore;
using thuytrang.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace thuytrang.Web.Tests
{
    [DependsOn(
        typeof(thuytrangWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class thuytrangWebTestModule : AbpModule
    {
        public thuytrangWebTestModule(thuytrangEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(thuytrangWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(thuytrangWebMvcModule).Assembly);
        }
    }
}