using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPlayground.Services.DictionaryManager
{
    public class DictionaryProviderByDefault : IDictionaryProvider
    {
        public string GetName(string defaultName)
        {
            return defaultName;
        }
    }
}