using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CountryStateApplication.Controllers
{
    public abstract class CountryStateApplicationControllerBase: AbpController
    {
        protected CountryStateApplicationControllerBase()
        {
            LocalizationSourceName = CountryStateApplicationConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
