using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CountryStateApplication.Localization
{
    public static class CountryStateApplicationLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CountryStateApplicationConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CountryStateApplicationLocalizationConfigurer).GetAssembly(),
                        "CountryStateApplication.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
