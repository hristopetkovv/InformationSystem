using InformationSystemServer.Data.Enums;
using InformationSystemServer.Data.Models;
using InformationSystemServer.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();

        Task<IEnumerable<Post>> GetPostsByFilterAsync(MessageSerachFilterDto filter);

        Task<Post> GetPostByIdAsync(int id);

        Task<Post> AddPostAsync(Post post);

        Task UpdatePostAsync(int id, Post post);

        Task DeletePostAsync(int id);

        Task<Post> ChangeStatusAsync(int postId, PostStatus status);
    }
}