using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CountryStateApplication.Configuration;

namespace CountryStateApplication.Web.Host.Startup
{
    [DependsOn(
       typeof(CountryStateApplicationWebCoreModule))]
    public class CountryStateApplicationWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CountryStateApplicationWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CountryStateApplicationWebHostModule).GetAssembly());
        }
    }
}
