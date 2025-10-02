using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DIPlayground.Config
{
    public class DictionarySection : ConfigurationSection
    {
        [ConfigurationProperty("names")]
        public NameValueConfigurationCollection Names => (NameValueConfigurationCollection)this["names"];
    }
}