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
        public IActionResult getAllBlogs() {

            var blog = new Blog
            {
                Id = 1,
                Title = "First Post",
                Content = "This is my first blog post"
            };

            return Ok(blog);
        }

        [HttpPost]
        public IActionResult createBlog([FromBody])
        {

            var blog = new Blog
            {
                Id = 1,
                Title = "First Post",
                Content = "This is my first blog post"
            };

            return Ok(blog);
        }

        [HttpPut]
        public IActionResult updateBlog([FromBody])
        {

            var blog = new Blog
            {
                Id = 1,
                Title = "First Post",
                Content = "This is my first blog post"
            };

            return Ok(blog);
        }
    }
}
