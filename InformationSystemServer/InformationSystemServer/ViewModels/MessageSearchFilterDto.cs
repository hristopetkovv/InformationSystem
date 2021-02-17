﻿using InformationSystemServer.Data.Enums;
using System;

namespace InformationSystemServer.ViewModels.Application
{
    public class MessageSerachFilterDto
    {
        public string Content { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public PostStatus? Status { get; set; }
    }
}