using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPlayground.Services.DictionaryManager
{
    public class FallbackDictionaryProvider : IDictionaryProvider
    {
        DictionaryProviderByConfig _configProvider;
        DictionaryProviderByDefault _defaultProvider;

        public FallbackDictionaryProvider()
        {
            _configProvider = new DictionaryProviderByConfig();
            _defaultProvider = new DictionaryProviderByDefault();
        }

        public string GetName(string defaultName)
        {
            string nameByConfig = _configProvider.GetName(defaultName);
            string nameByDefault = _defaultProvider.GetName(defaultName);

            return (nameByConfig != null) ? nameByConfig : nameByDefault;
        }
    }
}