using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace thuytrang.Controllers
{
    public abstract class thuytrangControllerBase: AbpController
    {
        protected thuytrangControllerBase()
        {
            LocalizationSourceName = thuytrangConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
