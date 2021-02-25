using InformationSystemServer.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.Services.ViewModels.Message;
using InformationSystemServer.Services.ViewModels.Application;
using InformationSystemServer.Services.ExtensionMethods;
using InformationSystemServer.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace InformationSystemServer.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public MessageService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync(MessageSearchFilterDto filter)
        {
            return await this.dbContext
                .Messages
                .Where(x =>
                    x.StartDate <= DateTime.UtcNow &&
                   (x.EndDate >= DateTime.UtcNow || x.EndDate == null))
                .FilterMessages(filter)
                .ProjectTo<MessageDto>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.StartDate)
                .ThenBy(x => x.EndDate)
                .ToListAsync();
        }

        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            return await this.dbContext
                .Messages
                .Where(x => x.Id == id)
                .ProjectTo<MessageDto>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.StartDate)
                .SingleOrDefaultAsync();
        }

        public async Task<MessageDto> AddMessageAsync(MessageDto message)
        {
            message.Status = MessageStatus.Draft;

            var newMessage = this.mapper.Map<Message>(message);

            this.dbContext.Messages.Add(newMessage);

            await this.dbContext.SaveChangesAsync();

            message.Id = newMessage.Id;

            return message;
        }

        public async Task UpdateMessageAsync(int id, MessageDto message)
        {
            var existingMessage = this.mapper.Map<Message>(message);

            this.dbContext.Entry(existingMessage).State = EntityState.Modified;

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
