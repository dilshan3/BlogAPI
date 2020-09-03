using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Entity;
using BlogAPI.DatabaseContext;
using BlogAPI.Services;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private DataContext _dataContext;
        private IBlogService _blogService;
        public BlogController(DataContext dataContext, IBlogService blogService)
        {
            _dataContext = dataContext;
            _blogService = blogService;
        }

        //Http method to retrieve all blogs 
        [HttpGet]
        public IActionResult GetAllBlogs() {

            var blogs = _blogService.GetAllBlogPosts();

            if (blogs.Count == 0)
            {

                return NotFound("No blog posts found");
            }
            else
            {
                return Ok(blogs);
            }

        }

        //Http method to retrieve a blog by using id
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBlog(int Id)
        {
            var blog = _blogService.GetBlogPost(Id);

            if (blog == null)
            {
                return NotFound("Blog with given ID is not found.");
            }
            else if (blog.Title == null || blog.Content == null)
            {
                if (blog.Title == null)
                {
                    return BadRequest("Blog doesn't have a title.");
                }
                else
                {
                    return BadRequest("Blog doesn't have content.");
                }

            }
            else {


                return Ok(blog);

            }

        }

        //Http method to create a new blog
        [HttpPost]
        public IActionResult CreateBlog([FromBody] Blog newBlog)
        {
            var blog = _blogService.CreateBlogPost(newBlog);
            
            return Ok(blog);
        }


        //Http method to update the blog post by adding comments
        [Route("comment/{id}")]
        [HttpPut]
        public IActionResult AddComment(int Id, [FromBody] Comment AddedComment)
        {
            var blog = _blogService.GetBlogPost(Id);

            if (blog == null)
            {
                return NotFound("Blog with given ID is not found.");
            }
            else if (blog.Title == null || blog.Content == null)
            {
                if (blog.Title == null)
                {
                    return BadRequest("Blog post doesn't have a title.");
                }
                else
                {
                    return BadRequest("Blog post doesn't have content.");
                }

            }
            else
            {
                blog = _blogService.AddComment(blog, AddedComment);
                
                return Ok(blog.Comments.ToArray());
            }
        }

        //Http method to update the blog post by changing blog post properties
        [Route("{Id}")]
        [HttpPut]
        public IActionResult UpdateBlog(int Id, [FromBody] Blog updatedBlog)
        {

            var blog =_blogService.GetBlogPost(Id);

            if (blog == null)
            {
                return NotFound("Blog with given ID is not found.");
            }
            else if (blog.Title == null || blog.Content == null)
            {
                if (blog.Title == null)
                {
                    return BadRequest("Blog post doesn't have a title.");
                }
                else
                {
                    return BadRequest("Blog post doesn't have content.");
                }

            }
            else
            {
                blog = _blogService.UpdateBlogPost(blog, updatedBlog);

                return Ok(blog);
            }

        }

        //Http method to delete the blog post 
        [Route("{Id}")]
        [HttpDelete]
        public IActionResult DeleteBlog(int Id) 
        {
            var blog = _blogService.GetBlogPost(Id);

            if (blog == null)
            {
                return NotFound("Blog with given ID is not found.");
            }
            else {

                blog = _blogService.DeleteBlogPost(blog);

                return Ok(blog);
            }
        }
    }
}
