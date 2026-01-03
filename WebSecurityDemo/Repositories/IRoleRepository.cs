using System.Collections.Generic;
using WebSecurityDemo.ViewModels;

namespace WebSecurityDemo.Repositories
{
    public interface IRoleRepository
    {
        List<RoleVM> GetAllRoles();
        RoleVM? GetRole(string roleName);
        bool CreateRole(string roleName);
        bool DeleteRole(string roleName);
    }
}