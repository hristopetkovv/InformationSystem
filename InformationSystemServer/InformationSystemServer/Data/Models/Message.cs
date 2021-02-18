using InformationSystemServer.Infrastructure.Enums;
using System;

namespace InformationSystemServer.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public MessageStatus Status { get; set; }
    }
}
