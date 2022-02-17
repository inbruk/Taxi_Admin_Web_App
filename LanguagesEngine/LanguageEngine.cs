using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessTools.LanguageEngine
{
    /// Внимание !!! Позже переделать на задание и сохранение/загрузку в сессию
    public static class LanguageEngine
    {
        private static LanguageIds currId = LanguageIds.Russian;
        public static LanguageIds CurrentLanguageId // Внимание !!! Позже переделать на задание и сохранение/загрузку в сессию
        {
            get
            {
                return currId;
            }
            //set
            //{
            //    currId = value;
            //}
        }

        public static Dictionary<int, String> GetLanguagesDictionary()
        {
            return LanguagePool.GetLanguagesDictionary();
        }

        public static String GetAcceptLanguageHeaderValueById()
        {
            return LanguagePool.GetAcceptLanguageHeaderValueById(currId);
        }

    }
}
