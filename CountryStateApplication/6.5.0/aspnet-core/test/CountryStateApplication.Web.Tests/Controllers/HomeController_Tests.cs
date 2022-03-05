using System.Threading.Tasks;
using CountryStateApplication.Models.TokenAuth;
using CountryStateApplication.Web.Controllers;
using Shouldly;
using Xunit;

namespace CountryStateApplication.Web.Tests.Controllers
{
    public class HomeController_Tests: CountryStateApplicationWebTestBase
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