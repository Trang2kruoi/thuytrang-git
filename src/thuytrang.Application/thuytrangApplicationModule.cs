using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using thuytrang.Authorization;

namespace thuytrang
{
    [DependsOn(
        typeof(thuytrangCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class thuytrangApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<thuytrangAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(thuytrangApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
