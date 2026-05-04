using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace thuytrang.Localization
{
    public static class thuytrangLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(thuytrangConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(thuytrangLocalizationConfigurer).GetAssembly(),
                        "thuytrang.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
