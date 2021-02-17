using InformationSystemServer.Data.Models;
using InformationSystemServer.ViewModels.Application;
using System.Linq;

namespace InformationSystemServer.ExtensionMethods
{
    public static class SearchMessageExtension
    {
        public static IQueryable<Post> FilterPosts(this IQueryable<Post> posts, MessageSerachFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Content))
            {
                posts = posts.Where(x => x.Content.Contains(filter.Content));
            }
            if (!string.IsNullOrEmpty(filter.StartDate.ToString()))
            {
                posts = posts.Where(x => x.StartDate == filter.StartDate);

            }
            if (!string.IsNullOrEmpty(filter.EndDate.ToString()))
            {
                posts = posts.Where(x => x.EndDate == filter.EndDate);
            }
            if (filter.Status.HasValue)
            {
                posts = posts.Where(x => x.Status == filter.Status.Value);
            }

            return posts;
        }
    }
}
