using logo_odev5.Models;
using logo_odev5.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using logo_odev5.DTOs;

namespace logo_odev5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [Route("GetAllPosts")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = postService.GetAllPosts().Select(x => new PostDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Title = x.Title,
                Body = x.Body
            });
            return Ok(new PostResponse { Data = posts, Success = true });
        }

        [Route("GetPostById/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var post = postService.GetPostById(x => x.Id == id);
            if (post == null)
            {
                return NotFound(new PostResponse { Success = false, Error = "Post not found" });
            }
            return Ok(new PostResponse
            {
                Data = new PostDto
                {
                    Id = post.Id,
                    UserId = post.UserId,
                    Title = post.Title,
                    Body = post.Body
                },
                Success = true
            });
        }
    }
}
