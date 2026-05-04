using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace thuytrang.Authorization
{
    public class thuytrangAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Reviews, L("Reviews"));
            // Khai báo quyền cho trang Reviews.
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, thuytrangConsts.LocalizationSourceName);
        }
    }
}
