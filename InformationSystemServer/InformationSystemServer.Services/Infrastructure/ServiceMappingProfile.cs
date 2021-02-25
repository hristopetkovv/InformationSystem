using AutoMapper;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services.ViewModels.Application;
using InformationSystemServer.Services.ViewModels.Message;

namespace InformationSystemServer.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            //Map for Application model
            this.CreateMap<Application, ApplicationResponseDto>();

            this.CreateMap<ApplicationRequestDto, Application>().ForMember(a => a.UserId, cfg => cfg.Ignore());

            this.CreateMap<ApplicationDetailsDto, Application>();

            this.CreateMap<Application, ApplicationDetailsDto>().ForMember(a => a.QualificationInformation, cfg => cfg.MapFrom(x => x.QualificationInformation));

            //Map for Qualification model
            this.CreateMap<QualificationDto, QualificationInformation>();

            this.CreateMap<QualificationInformation, QualificationDto>();

            //Map for Message model
            this.CreateMap<Message, MessageDto>();

            this.CreateMap<MessageDto, Message>();

        }
    }
}
