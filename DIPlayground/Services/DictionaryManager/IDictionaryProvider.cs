using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPlayground.Services.DictionaryManager
{
    public interface IDictionaryProvider
    {
        string GetName(string defaultName);
    }
}
