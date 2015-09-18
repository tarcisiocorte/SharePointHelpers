using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.SharePoint.Utilities
{
    public static class ItemsHelper
    {
        public static void AddPermissionsToItem(SPWeb web, SPListItem item, Dictionary<SPPrincipal, string[]> assignments)
        {
            if (!item.HasUniqueRoleAssignments)
                item.BreakRoleInheritance(false);
            while (item.RoleAssignments.Count > 0)
                item.RoleAssignments.Remove(0);

            foreach (SPPrincipal principal in assignments.Keys)
            {
                foreach (string itemAssignment in assignments[principal])
                {
                    SPRoleDefinition roleDef = GetPermissionLevel(web, itemAssignment);
                    if (roleDef == null)
                        continue;
                    SPRoleAssignment roleAssignment = new SPRoleAssignment(principal);
                    roleAssignment.RoleDefinitionBindings.Add(roleDef);
                    item.RoleAssignments.Add(roleAssignment);
                }
            }
            //item.Update();
        }

        public static SPRoleDefinition GetPermissionLevel(SPWeb web, string name)
        {
            foreach (SPRoleDefinition roleDef in web.RoleDefinitions)
                if (roleDef.Name == name)
                    return roleDef;
            return null;
        }
    }
}
