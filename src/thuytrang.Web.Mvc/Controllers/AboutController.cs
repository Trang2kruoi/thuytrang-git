using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using thuytrang.Controllers;

namespace thuytrang.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : thuytrangControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
