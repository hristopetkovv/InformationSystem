using InformationSystemServer.Services;
using InformationSystemServer.ViewModels.Application;
using InformationSystemServer.ViewModels.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class MessageController : BaseApiController
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<IEnumerable<MessageDto>> GetMessages([FromQuery] MessageSearchFilterDto filter)
        {
            return await this.messageService.GetMessagesAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<MessageDto> GetMessageById(int id)
        {
            return await this.messageService.GetMessageByIdAsync(id);
        }

        [HttpPost]
        public async Task<MessageDto> AddMessage(MessageDto message)
        {
            return await this.messageService.AddMessageAsync(message);
        }

        [HttpPut("{id:int}")]
        public async Task UpdateMessage(int id, [FromBody] MessageDto message)
        {
            await this.messageService.UpdateMessageAsync(id, message);
        }

        
    }
}
