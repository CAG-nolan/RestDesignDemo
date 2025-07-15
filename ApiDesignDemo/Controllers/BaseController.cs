using Microsoft.AspNetCore.Mvc;

namespace ApiDesignDemo.Controllers
{
    [ApiController]
    public abstract class BaseController<T> : ControllerBase
    {
        // Common logic for all controllers can go here
    }
}
