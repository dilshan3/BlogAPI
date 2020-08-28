using BlogAPI.DatabaseContext;
using BlogAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public interface IBlogService {

        Blog CreateBlogPost(Blog blog);
        List<Blog> GetAllBlogPosts();
        Blog GetBlogPost(int Id);
        Blog AddComment(Blog blog, Comment comment);
        Blog UpdateBlogPost(Blog blog, Blog updatedBlog);
        Blog DeleteBlogPost(Blog blog);
    }
    public class BlogService:IBlogService
    {
        private readonly DataContext _dataContext;

        public BlogService(DataContext datacontext) 
        {
            _dataContext = datacontext;
        }

        public Blog CreateBlogPost(Blog blog) 
        {
            blog.BlogUrl = "https://blogssite.com/" + blog.Title.Trim();
            _dataContext.Blogs.Add(blog);
            _dataContext.SaveChanges();
            return blog;
        }

        public Blog GetBlogPost(int Id)
        {
            var b = _dataContext.Blogs.Where(b => b.Id == Id).SingleOrDefault();
            return b;
        }

        public List<Blog> GetAllBlogPosts() 
        {
            var blogs = _dataContext.Blogs.ToList();
            return blogs;
        }

        public Blog AddComment(Blog blog, Comment comment) 
        {
            comment.BlogId = blog.Id;
            blog.Comments.Add(comment);
            _dataContext.Update(blog);
            _dataContext.SaveChanges();

            return blog;
        }

        public Blog DeleteBlogPost(Blog blog) 
        {
            _dataContext.Remove(blog);
            _dataContext.SaveChanges();
            return blog;
        }

        public Blog UpdateBlogPost(Blog blog, Blog updatedBlog)
        {
            blog.Title = updatedBlog.Title;
            blog.Content = updatedBlog.Content;
            blog.ImgUrl = updatedBlog.ImgUrl;
            blog.BlogUrl = "https://blogssite.com/" + updatedBlog.Title;
            _dataContext.Update(blog);
            _dataContext.SaveChanges();

            return blog;
        }
    }
}
