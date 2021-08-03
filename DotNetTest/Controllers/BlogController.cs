using System;
using System.Collections.Generic;
using System.Linq;
using DotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public List<Blog> Get()
        {
            using var db = new BloggingContext();
            return db.Blogs
                .OrderBy(b => b.Url)
                .ToList();
        }

        [HttpGet("add-sample")]
        public void AddSampleBlog()
        {
            using var db = new BloggingContext();

            db.Blogs.Add(new Blog {Url = "http://sample.com"});
            db.SaveChanges();
        }
        
        
        
    }
}