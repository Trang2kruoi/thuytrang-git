using Abp.Authorization;
using thuytrang.Authorization.Roles;
using thuytrang.Authorization.Users;

namespace thuytrang.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
