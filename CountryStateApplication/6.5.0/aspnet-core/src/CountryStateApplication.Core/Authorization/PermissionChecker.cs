using Abp.Authorization;
using CountryStateApplication.Authorization.Roles;
using CountryStateApplication.Authorization.Users;

namespace CountryStateApplication.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
