﻿using InformationSystemServer.Data.Enums;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services;
using InformationSystemServer.ViewModels.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class MessageController : BaseApiController
    {
        private readonly IMessageService postService;

        public MessageController(IMessageService postService)
        {
            this.postService = postService;
        }

        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<IEnumerable<Post>> GetPosts([FromQuery] MessageSearchFilterDto filter)
        {
            return await postService.GetPostsAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<Post> GetPostById(int id)
        {
            return await postService.GetPostByIdAsync(id);
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
