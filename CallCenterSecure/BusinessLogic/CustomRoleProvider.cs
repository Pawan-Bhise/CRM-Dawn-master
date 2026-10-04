using CallCenter.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenter.BusinessLogic
{
    public class CustomRoleProvider
    {
        public string GetRoleNameById(int roleId)
        {
            string roleName = string.Empty;
            using (AuthenticationDB dbContext = new DataAccess.AuthenticationDB())
            {
                roleName = (from role in dbContext.Roles where role.RoleId == roleId
                            select role.RoleName).SingleOrDefault();
                
            }
            return roleName;
        }

        public List<Role> GetAllRoles()
        {
            using (AuthenticationDB dbContext = new DataAccess.AuthenticationDB())
            {
                List<Role> roleList = new List<Role>();
                roleList = (from role in dbContext.Roles select role).ToList();
                return roleList;
            }
        }
    }
}