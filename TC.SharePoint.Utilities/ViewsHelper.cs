using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.SharePoint.Utilities
{
    public static class ViewsHelper
    {
        /// <summary>
        /// This method create view in order to show files of a list without show the folders of files.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="viewTitle"></param>
        /// <param name="fieldsToShow"></param>
        /// <param name="bMakeViewDefault"></param>
        public static void AddViewToListShowOnlyFiles(SPList list, string viewTitle, string[] fieldsToShow, bool bMakeViewDefault)
        {
            string viewName = GetValidStrForUrl(viewTitle);
            System.Collections.Specialized.StringCollection collViewFields = new System.Collections.Specialized.StringCollection();
            foreach (string fieldStr in fieldsToShow)
                collViewFields.Add(list.Fields.GetField(fieldStr).InternalName);
            SPView view = list.Views.Add(viewName, collViewFields, null, 30, true, bMakeViewDefault);
            view.Scope = SPViewScope.Recursive;
            view.Title = viewTitle;
            view.Update();
        }

        /// <summary>
        /// This method create view in order to show files of a list without show the folders of files.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="viewTitle"></param>
        /// <param name="fieldsToShow"></param>
        public static void AddViewToListShowOnlyFiles(SPList list, string viewTitle, string[] fieldsToShow)
        {
            string viewName = GetValidStrForUrl(viewTitle);
            System.Collections.Specialized.StringCollection collViewFields = new System.Collections.Specialized.StringCollection();
            foreach (string fieldStr in fieldsToShow)
                collViewFields.Add(list.Fields.GetField(fieldStr).InternalName);
            SPView view = list.Views.Add(viewName, collViewFields, null, 30, true, false);
            view.Scope = SPViewScope.Recursive;
            view.Title = viewTitle;
            view.Update();
        }

        /// <summary>
        /// This method add a new View to a List.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="viewTitle"></param>
        /// <param name="fieldsToShow"></param>
        public static void AddViewToList(SPList list, string viewTitle, string[] fieldsToShow)
        {
            string viewName = GetValidStrForUrl(viewTitle);
            System.Collections.Specialized.StringCollection collViewFields = new System.Collections.Specialized.StringCollection();
            foreach (string fieldStr in fieldsToShow)
                collViewFields.Add(list.Fields.GetField(fieldStr).InternalName);
            SPView view = list.Views.Add(viewName, collViewFields, null, 30, true, false);
            view.Title = viewTitle;
            view.Update();
        }

        /// <summary>
        /// This method add a new View to a List.
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listTitle"></param>
        /// <param name="viewName"></param>
        /// <param name="viewTitle"></param>
        /// <param name="viewfields"></param>
        /// <param name="defaultView"></param>
        public static void AddViewToList(SPWeb web, string listTitle, string viewName, string viewTitle, string[] viewfields, bool defaultView)
        {
            SPList list = web.Lists[listTitle];
            AddViewToList(list, viewName, viewTitle, viewfields, defaultView, null);
        }

        /// <summary>
        /// This method add a new View to a List.
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listTitle"></param>
        /// <param name="viewName"></param>
        /// <param name="viewTitle"></param>
        /// <param name="viewfields"></param>
        /// <param name="defaultView"></param>
        /// <param name="query"></param>
        public static void AddViewToList(SPWeb web, string listTitle, string viewName, string viewTitle, string[] viewfields, bool defaultView, string query)
        {
            SPList list = web.Lists[listTitle];
            AddViewToList(list, viewName, viewTitle, viewfields, defaultView, query);
        }

        /// <summary>
        /// This method add a new View to a List.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="viewName"></param>
        /// <param name="viewTitle"></param>
        /// <param name="fieldsToShow"></param>
        /// <param name="defaultView"></param>
        /// <param name="query"></param>
        public static void AddViewToList(SPList list, string viewName, string viewTitle, string[] fieldsToShow, bool defaultView, string query)
        {
            //string viewName = GetValidStrForUrl(viewTitle);
            System.Collections.Specialized.StringCollection collViewFields = new System.Collections.Specialized.StringCollection();
            foreach (string fieldStr in fieldsToShow)
                collViewFields.Add(list.Fields.GetField(fieldStr).InternalName);
            SPView view = list.Views.Add(viewName, collViewFields, null, 30, true, false);
            view.Title = viewTitle;
            view.DefaultView = defaultView;
            if (!string.IsNullOrEmpty(query))
                view.Query = query;
            view.Update();
        }

        private static string GetValidStrForUrl(string viewTitle)
        {
            return viewTitle.Replace(" ", "");
        }
    }
}
