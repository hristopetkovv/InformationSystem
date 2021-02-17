using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using InformationSystemServer.Enums;
using InformationSystemServer.ViewModels.Application;
using InformationSystemServer.ExtensionMethods;
using InformationSystemServer.ViewModels.Message;

namespace InformationSystemServer.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext dbContext;

        public MessageService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync(MessageSearchFilterDto filter)
        {
            var messages = await this.dbContext
                .Messages
                .Where(x =>
                    x.StartDate <= DateTime.UtcNow &&
                   (x.EndDate >= DateTime.UtcNow || x.EndDate == null))
                .FilterMessages(filter)
                .Select(x => new MessageDto 
                { 
                    Id = x.Id,
                    Content = x.Content,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status
                })
                .OrderBy(x => x.StartDate)
                .ThenBy(x => x.EndDate)
                .ToListAsync();

            return messages;
        }

        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            return await this.dbContext
                .Messages
                .Where(x => x.Id == id)
                .Select(x => new MessageDto
                {
                    Id = x.Id,
                    Content = x.Content,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status
                })
                .SingleOrDefaultAsync();
        }

        public async Task<MessageDto> AddMessageAsync(MessageDto message)
        {
            message.Status = MessageStatus.Draft;

            var newMessage = new Message 
            {
                StartDate = message.StartDate,
                EndDate = message.EndDate,
                Content = message.Content,
                Status = MessageStatus.Draft
            };

            this.dbContext.Messages.Add(newMessage);

            await this.dbContext.SaveChangesAsync();

            return message;
        }

        public async Task UpdateMessageAsync(int id, MessageDto message)
        {
            var existingMessage = await this.dbContext
                .Messages
                .SingleOrDefaultAsync(p => p.Id == id);

            existingMessage.Content = message.Content;
            existingMessage.StartDate = message.StartDate;
            existingMessage.EndDate = message.EndDate;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(int messageId, MessageStatus status)
        {
            var message = await this.dbContext
                .Messages
                .SingleOrDefaultAsync(app => app.Id == messageId);

            message.Status = status;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await this.dbContext
                .Messages
                .SingleOrDefaultAsync(a => a.Id == id);

            this.dbContext.Messages.Remove(message);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
