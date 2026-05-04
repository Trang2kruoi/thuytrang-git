using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using thuytrang.Configuration;

namespace thuytrang.Web.Host.Startup
{
    [DependsOn(
       typeof(thuytrangWebCoreModule))]
    public class thuytrangWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public thuytrangWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(thuytrangWebHostModule).GetAssembly());
        }
    }
}
