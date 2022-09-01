using AutoMapper;
using Subscriber.Services.Models;
using Subscriber.WebApi.DTO;

namespace Subscriber.WebApi.Mapping
{
    public class SubscriberMap : Profile
    {
        public SubscriberMap()
        {
            CreateMap<SubscriberDTO, SubscriberModel>().ReverseMap();
        }
    }
}
