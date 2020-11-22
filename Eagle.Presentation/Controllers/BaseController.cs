using Eagle.Common.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Eagle.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
