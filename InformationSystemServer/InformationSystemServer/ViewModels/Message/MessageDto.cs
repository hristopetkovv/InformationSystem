using InformationSystemServer.Enums;
using System;

namespace InformationSystemServer.ViewModels.Message
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public MessageStatus Status { get; set; }
    }
}
