using System.Collections.Generic;

namespace Infrastructure.Constants
{
    public static class GenerateListPermissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>
            {
                $"Permissions.{module}.Read",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
                $"Permissions.{module}.Migrate",
                $"Permissions.{module}.UrgentFiles",
                $"Permissions.{module}.Search",
            };
        }
    }
}
