using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.ViewModels.Application;
using InformationSystemServer.ExtensionMethods;

namespace InformationSystemServer.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext context;
        public MessageService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            var posts = await context
                .Posts
                .Where(x =>
                    x.StartDate <= DateTime.UtcNow && 
                   (x.EndDate >= DateTime.UtcNow || x.EndDate == null))
                .ToListAsync();

            return posts;
        }

        public async Task<IEnumerable<Post>> GetPostsByFilterAsync(MessageSerachFilterDto filter)
        {
            var posts = await context
                .Posts
                .Where(x =>
                    x.StartDate <= DateTime.UtcNow &&
                   (x.EndDate >= DateTime.UtcNow || x.EndDate == null))
                .FilterPosts(filter)
                .ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await context.Posts.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            post.Status = PostStatus.Draft;
            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return post;
        }

        public async Task UpdatePostAsync(int id, Post post)
        {
            var existingPost = await context
                .Posts
                .SingleOrDefaultAsync(p => p.Id == id);

            existingPost.Content = post.Content;
            existingPost.StartDate = post.StartDate;
            existingPost.EndDate = post.EndDate;

            await context.SaveChangesAsync();
        }

        public async Task<Post> ChangeStatusAsync(int postId, PostStatus status)
        {
            var post = await context.Posts
                .SingleOrDefaultAsync(app => app.Id == postId);

            post.Status = status;

            await context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await context.Posts
             .SingleOrDefaultAsync(a => a.Id == id);

            context.Posts.Remove(post);

            await context.SaveChangesAsync();
        }

    }
}
