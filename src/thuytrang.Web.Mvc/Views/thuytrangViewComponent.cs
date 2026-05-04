using Abp.AspNetCore.Mvc.ViewComponents;

namespace thuytrang.Web.Views
{
    public abstract class thuytrangViewComponent : AbpViewComponent
    {
        protected thuytrangViewComponent()
        {
            LocalizationSourceName = thuytrangConsts.LocalizationSourceName;
        }
    }
}
