using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;

namespace TC.SharePoint.Utilities
{
    public static partial class Utils
    {
        /// <summary>
        /// Remove anonymous Access on List
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listTitle"></param>
        /// <returns></returns>
        public static bool RemoveAnonymousAccess(SPWeb web, string listTitle)
        {
            SPList list = web.Lists.TryGetList(listTitle);
            if (list != null && list.HasUniqueRoleAssignments)
            {
                list.AnonymousPermMask64 = SPBasePermissions.EmptyMask;
                list.Update();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove characters don't allowed to folder and file names
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string stringToConvert)
        {
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");
            stringToConvert = regex.Replace(stringToConvert, "");
            return stringToConvert;
        }
    }
}
