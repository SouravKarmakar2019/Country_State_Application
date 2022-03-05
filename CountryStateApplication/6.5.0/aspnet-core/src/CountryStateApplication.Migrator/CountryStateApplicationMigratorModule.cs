using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CountryStateApplication.Configuration;
using CountryStateApplication.EntityFrameworkCore;
using CountryStateApplication.Migrator.DependencyInjection;

namespace CountryStateApplication.Migrator
{
    [DependsOn(typeof(CountryStateApplicationEntityFrameworkModule))]
    public class CountryStateApplicationMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CountryStateApplicationMigratorModule(CountryStateApplicationEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CountryStateApplicationMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CountryStateApplicationConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CountryStateApplicationMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
