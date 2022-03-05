using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CountryStateApplication.Authorization;

namespace CountryStateApplication
{
    [DependsOn(
        typeof(CountryStateApplicationCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CountryStateApplicationApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CountryStateApplicationAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CountryStateApplicationApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
