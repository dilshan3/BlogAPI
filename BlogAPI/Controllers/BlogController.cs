﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Entity;
using BlogAPI.DatabaseContext;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private DataContext _dataContext;
        public BlogController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllBlogs() {

            var blogs = _dataContext.Blogs.ToList();
            if (blogs.Count == 0)
            {

                return NotFound("No blog posts found");
            }
            else 
            { 
                return Ok(blogs); 
            }
                
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBlog(int Id) 
        {
            var blog=_dataContext.Blogs.Where(b => b.Id == Id).SingleOrDefault();

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

        [HttpPost]
        public IActionResult CreateBlog([FromBody] Blog newBlog)
        {
            newBlog.BlogUrl = "https://blogssite.com/" + newBlog.Title;
            _dataContext.Blogs.Add(newBlog);
            _dataContext.SaveChanges();
            return Ok(newBlog);
        }


        //Http method to update the blog post by adding comments
        [Route("comment/{id}")]
        [HttpPut]
        public IActionResult AddComment(int Id,[FromBody] Comment AddedComment)
        {
            var blog = _dataContext.Blogs.Where(b => b.Id == Id).SingleOrDefault();

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
                blog.Comments.Add(AddedComment);
                _dataContext.SaveChanges();
                return Ok(blog.Comments.ToArray());
            }
        }

        [HttpPut]
        public IActionResult UpdateBlog()
        {

            var blog = new Blog
            {
                Id = 1,
                Title = "First Post",
                Content = "This is my first blog post"
            };

            return Ok(blog);
        }

        [HttpDelete]
        public IActionResult DeleteBlog() 
        {
            return Ok();
        }
    }
}
