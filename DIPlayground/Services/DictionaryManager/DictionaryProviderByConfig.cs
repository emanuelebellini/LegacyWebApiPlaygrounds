using DIPlayground.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DIPlayground.Services.DictionaryManager
{
    public class DictionaryProviderByConfig : IDictionaryProvider
    {
        public string GetName(string defaultName)
        {
            var section = (DictionarySection)ConfigurationManager.GetSection("dictionary");
            return section.Names[defaultName]?.Value;
        }
    }
}