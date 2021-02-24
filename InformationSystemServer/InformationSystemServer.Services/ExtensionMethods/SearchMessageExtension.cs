using InformationSystemServer.Data.Models;
using InformationSystemServer.Services.ViewModels.Application;
using System.Linq;

namespace InformationSystemServer.Services.ExtensionMethods
{
    public static class SearchMessageExtension
    {
        public static IQueryable<Message> FilterMessages(this IQueryable<Message> messages, MessageSearchFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Content))
            {
                messages = messages.Where(x => x.Content.Contains(filter.Content));
            }
            if (!string.IsNullOrEmpty(filter.StartDate.ToString()))
            {
                messages = messages.Where(x => x.StartDate == filter.StartDate);

            }
            if (!string.IsNullOrEmpty(filter.EndDate.ToString()))
            {
                messages = messages.Where(x => x.EndDate == filter.EndDate);
            }
            if (filter.Status.HasValue)
            {
                messages = messages.Where(x => x.Status == filter.Status.Value);
            }

            return messages;
        }
    }
}
