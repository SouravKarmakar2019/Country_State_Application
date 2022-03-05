using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CountryStateApplication.EntityFrameworkCore;
using CountryStateApplication.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CountryStateApplication.Web.Tests
{
    [DependsOn(
        typeof(CountryStateApplicationWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CountryStateApplicationWebTestModule : AbpModule
    {
        public CountryStateApplicationWebTestModule(CountryStateApplicationEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CountryStateApplicationWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CountryStateApplicationWebMvcModule).Assembly);
        }
    }
}