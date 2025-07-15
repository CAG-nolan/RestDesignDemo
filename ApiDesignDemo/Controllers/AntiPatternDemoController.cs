using Microsoft.AspNetCore.Mvc;

namespace ApiDesignDemo.Controllers
{
    [ApiController]
    [Route("api/user/{post}/likes")]
    public class AntiPatternDemoController : ControllerBase
    {
        // This is an example of a BAD endpoint design:
        // GET: api/user/{post}/likes
        // This is confusing because {post} is in the user segment, but is actually a post id.
        // It violates RESTful resource hierarchy and clarity.
        [HttpGet]
        public IActionResult BadExample(int post)
        {
            // ...implementation...
            return BadRequest("This endpoint is an anti-pattern. {post} should not be under user.");
        }
    }
}
