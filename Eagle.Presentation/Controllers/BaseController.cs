using Eagle.Common.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Eagle.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IStringLocalizer<Resources.Resources> _localizer;

        public BaseController(IStringLocalizer<Resources.Resources> localizer)
        {
            _localizer = localizer;
        }
    }
}
