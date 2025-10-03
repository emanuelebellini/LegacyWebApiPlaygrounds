using DIPlayground.Services.DictionaryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPlayground.Services
{
    public class MyConsumerService : IMyConsumerService
    {
        private IDictionaryProvider _dictionaryProvider;

        public MyConsumerService(IDictionaryProvider dictionaryProvider)
        {
            _dictionaryProvider = dictionaryProvider;
        }

        public string MyHandmadeTest()
        {
            string result = _dictionaryProvider.GetName("default");
            return (result == "overridden") ? "Yay!" : "Noooooooooooo...";
        } 
    }
}