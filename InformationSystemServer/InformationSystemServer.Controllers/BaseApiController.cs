using Microsoft.AspNetCore.Mvc;

namespace InformationSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
