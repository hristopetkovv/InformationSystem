﻿using InformationSystemServer.Data.Enums;
using System;

namespace InformationSystemServer.Services.ViewModels.Application
{
    public class QualificationDto
    {
        public int? QualificationId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationDays { get; set; }

        public string Description { get; set; }

        public TypeQualification TypeQualification { get; set; }
    }
}
