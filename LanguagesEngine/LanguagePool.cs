using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessTools.LanguageEngine
{
    internal static class LanguagePool
    {
        private static List<LanguageItem> _items = 
            new List<LanguageItem>()
            {
                new LanguageItem() { Id = LanguageIds.Russian, Name = "Русский", AcceptLanguageHeaderValue = "ru-ru"  },
                new LanguageItem() { Id = LanguageIds.English, Name = "English", AcceptLanguageHeaderValue = "en-us"  }
            };

        public static Dictionary<int,String> GetLanguagesDictionary()
        {
            var result = new Dictionary<int, String>();

            foreach (var currItem in _items)
                result.Add( (int) currItem.Id, currItem.Name );

            return result;
        }

        public static String GetAcceptLanguageHeaderValueById(LanguageIds id)
        {
            return _items.Where(x => x.Id == id).Single().AcceptLanguageHeaderValue;
        }
    }
}
