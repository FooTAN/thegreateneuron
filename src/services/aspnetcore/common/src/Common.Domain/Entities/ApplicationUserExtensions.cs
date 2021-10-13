using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Entities
{
    public static class ApplicationUserExtensions
    {
        public static void AddRoles(this ApplicationUser user, params string[] roles)
        {
            var roleList = user.Roles.Split(',').Select(x => x.Trim()).Select(x => x.ToLower()).ToList();
            foreach (var role in roles)
            {
                if (roleList.Any(role.ToLower().Contains))
                    break;

                roleList.Add(role);
            }

            user.Roles = string.Join(',', roleList);
        }

        public static void RemoveRoles(this ApplicationUser user, params string[] roles)
        {
            var roleList = user.Roles.Split(',').Select(x => x.Trim()).Select(x => x.ToLower()).ToList();
            foreach (var role in roles)
            {
                roleList.Remove(role);
            }

            user.Roles = string.Join(',', roleList);
        }

        public static bool IsInRole(this ApplicationUser user, string role)
        {
            var roleList = user.Roles.Split(',').Select(x => x.Trim()).Select(x => x.ToLower()).ToList();

            return roleList.Contains(role);
        }
    }
}
