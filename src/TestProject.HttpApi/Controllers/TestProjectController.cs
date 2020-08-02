using TestProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TestProjectController : AbpController
    {
        protected TestProjectController()
        {
            LocalizationResource = typeof(TestProjectResource);
        }
    }
}