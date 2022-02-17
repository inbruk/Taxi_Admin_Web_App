namespace Rapport.BusinessTools.DirectoryEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class DirectoryDefinitionPool
    {
        private static List<DirectoryDefinition> _items =
            new List<DirectoryDefinition>()
            {
                new DirectoryDefinition() { Id = DirectoryIds.ProfileState, LastPartOfUrl = "profile-states" }
            };

        public static DirectoryDefinition GetItemById(DirectoryIds dirId)
        {
            return _items.Where(x => x.Id == dirId).Single();
        }

        public static String GetLastPartOfUrlById(DirectoryIds dirId)
        {
            return _items.Where(x => x.Id == dirId).Single().LastPartOfUrl;
        }
    }
}
