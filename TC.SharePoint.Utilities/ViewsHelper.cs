using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.SharePoint.Utilities
{
    public class ViewsHelper
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

        private static string GetValidStrForUrl(string viewTitle)
        {
            return viewTitle.Replace(" ", "");
        }
    }
}
