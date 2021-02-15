using InformationSystemServer.Data.Enums;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();

        Task<Post> AddPostAsync(Post post);

        Task UpdatePostAsync(int id, Post post);

        Task DeletePostAsync(int id);
        Task<Post> ChangeStatusAsync(int postId, PostStatus status);
    }
}