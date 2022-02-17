namespace Rapport.BusinessTools.DirectoryEngine
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Rapport.AuxiliaryTools.AsyncHelper;
    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.AuxiliaryTools.GenericsAndTemplates;
    using Rapport.AuxiliaryTools.AspNetStoragesInClassLib;
 
    public static class DirectoryPool
    {
        private static String GetStorageName(String LastPartOfUrl)
        {
            String storageName = "Directory_" + LastPartOfUrl;
            return storageName;
        }

        private static List<DirectoryItem> GetDirectoryFromStorage(String storageName)
        {
            var applWrap = ApplicationStateWrapperLazy.Instance;
            var currItem = (List<DirectoryItem>)applWrap[storageName];
            return currItem;
        }

        private static DirectoryController dirControl = null;
        private static List<DirectoryItem> LoadDirectory(DirectoryIds dirId)
        {
            if( dirControl==null)
            {
                DirectoryControllerBuilder dirContBuilder = new DirectoryControllerBuilder();
                dirControl = dirContBuilder.GetResult();
            }

            JsonArray<DirectoryItem> arr =
                AsyncHelper.RunSync< JsonArray<DirectoryItem> >
                (
                    () => dirControl.LoadDirectoryAsync(dirId)
                );

            if (arr == null)
                arr = new JsonArray<DirectoryItem>(null);

            var result = arr.Items.ToList();
            return result;
        }

        private static void CacheDirectory(List<DirectoryItem> dirValues, String storageName)
        {
            var applWrap = ApplicationStateWrapperLazy.Instance;
            applWrap[storageName] = dirValues;
        }

        public static List<DirectoryItem> GetDirectoryValuesById( DirectoryIds dirId )
        {
            DirectoryDefinition def = DirectoryDefinitionPool.GetItemById(dirId);
            String storageName = GetStorageName(def.LastPartOfUrl);
            List<DirectoryItem> result = GetDirectoryFromStorage(storageName);
            if (result == null) // если словаря в хранилище нет, то грузим его, помещаем в Appication[] и возвращаем
            {
                result = LoadDirectory(dirId);
                CacheDirectory(result, storageName);
            }

            return result;
        }
    }
}
