using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace thuytrang.Web.Views
{
    public abstract class thuytrangRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected thuytrangRazorPage()
        {
            LocalizationSourceName = thuytrangConsts.LocalizationSourceName;
        }
    }
}
