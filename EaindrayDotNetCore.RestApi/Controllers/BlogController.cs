﻿using EaindrayDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EaindrayDotNetCore.RestApi.Controllers
{
         // api/blog
        [Route("api/[controller]")]
        [ApiController]
        public class BlogController : ControllerBase
        {
            [HttpGet]
            public IActionResult GetBlogs()
            {
                //try
                //{
                //    AppDbContext db = new AppDbContext();
                //    List<BlogDataModel> lst = db.Blogs.ToList();
                //    //BlogListResponseModel model = new BlogListResponseModel();
                //    //model.IsSuccess = true;
                //    //model.Message = "Success";
                //    //model.Data = lst;
                //    BlogListResponseModel model = new BlogListResponseModel
                //    {
                //        IsSuccess = true,
                //        Message = "Success",
                //        Data = lst,
                //    };
                //    return Ok(model);
                //}
                //catch (Exception ex)
                //{
                //    return Ok(new BlogListResponseModel
                //    {
                //        IsSuccess = false,
                //        //Message = ex.ToString(), // detail error
                //        Message = ex.Message, // summary error
                //    });
                //}

                AppDbContext db = new AppDbContext();
                List<BlogDataModel> lst = db.Blogs.ToList();
                BlogListResponseModel model = new BlogListResponseModel
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = lst,
                };
                return Ok(model);
            }

            [HttpGet("{id}")]
            public IActionResult GetBlog(int id)
            {
                AppDbContext db = new AppDbContext();
                var item = db.Blogs.FirstOrDefault(x => x.Blog_Id == id);
                if (item is null)
                {
                    var response = new { IsSuccess = false, Message = "No data found." };
                    return NotFound(response);
                }
                return Ok(item);
            }

            [HttpPost]
            public IActionResult CreateBlog(BlogDataModel blog)
            {
                AppDbContext db = new AppDbContext();
                db.Blogs.Add(blog);
                var result = db.SaveChanges();

                BlogResponseModel model = new BlogResponseModel()
                {
                    IsSuccess = result > 0,
                    Message = result > 0 ? "Saving Successful." : "Saving Failed.",
                    Data = blog
                };
                return Ok(model);
            }

            [HttpPut]
            public IActionResult UpdateBlog()
            {
                return Ok("UpdateBlog");
            }

            [HttpPatch]
            public IActionResult PatchBlog()
            {
                return Ok("PatchBlog");
            }

            [HttpDelete]
            public IActionResult DeleteBlog()
            {
                return Ok("DeleteBlog");
            }
        }
    }