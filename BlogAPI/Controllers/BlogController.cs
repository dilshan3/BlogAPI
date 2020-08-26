using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Entity;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult getBlog() {

            var blog = new Blog
            {
                id = 1,
                title = "First Post",
                content = "This is my first blog post"
            };

            return Ok(blog);
        }
    }
}
