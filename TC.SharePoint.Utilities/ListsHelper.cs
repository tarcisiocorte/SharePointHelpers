using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.SharePoint.Utilities
{
    public static class ListsHelper
    {

        /// <summary>
        /// Create a new list
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listName"></param>
        /// <param name="listTitle"></param>
        /// <param name="listDescription"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static SPList EnsureListCreation(SPWeb web, string listName, string listTitle, string listDescription, SPListTemplateType type)
        {
            EnsureListCleanup(web, listTitle);
            Guid listGuid = web.Lists.Add(listName, listDescription, type);
            SPList createdList = web.Lists.GetList(listGuid, true);
            createdList.Title = listTitle;
            createdList.Update();
            return createdList;
        }

        /// <summary>
        /// Ensure that the list will be deleted.
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listTitle"></param>
        public static void EnsureListCleanup(SPWeb web, string Title)
        {
            SPList list = web.Lists.TryGetList(Title);
            if (list != null)
                list.Delete();
        }
    }
}
