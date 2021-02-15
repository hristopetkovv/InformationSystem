using InformationSystemServer.Data.Enums;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class PostController : BaseApiController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await postService.GetAllPostsAsync();
        }

        [HttpPost]
        public async Task<Post> AddPost(Post post)
        {
            return await postService.AddPostAsync(post);
        }

        [HttpPut("{id:int}")]
        public async Task UpdatePost(int id, [FromBody] Post post)
        {
            await postService.UpdatePostAsync(id, post);
        }

        [HttpPut("status/{id:int}")]
        public async Task<Post> ChangeStatus(int id, [FromBody] PostStatus status)
        {
            return await postService.ChangeStatusAsync(id, status);
        }

    }
}
