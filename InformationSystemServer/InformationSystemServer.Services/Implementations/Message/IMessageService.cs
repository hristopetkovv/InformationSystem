﻿using InformationSystemServer.Data.Enums;
using InformationSystemServer.Services.ViewModels.Application;
using InformationSystemServer.Services.ViewModels.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Implementations
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetMessagesAsync(MessageSearchFilterDto filter);

        Task<MessageDto> GetMessageByIdAsync(int id);

        Task<MessageDto> AddMessageAsync(MessageDto message);

        Task UpdateMessageAsync(int id, MessageDto message);

        Task DeleteMessageAsync(int id);

        Task ChangeStatusAsync(int messageId, MessageStatus status);
    }
}