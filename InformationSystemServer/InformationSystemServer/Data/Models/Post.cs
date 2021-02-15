using InformationSystemServer.Data.Enums;
using System;

namespace InformationSystemServer.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PostStatus Status { get; set; }
    }
}
