using System.Threading.Tasks;
using thuytrang.Models.TokenAuth;
using thuytrang.Web.Controllers;
using Shouldly;
using Xunit;

namespace thuytrang.Web.Tests.Controllers
{
    public class HomeController_Tests: thuytrangWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}