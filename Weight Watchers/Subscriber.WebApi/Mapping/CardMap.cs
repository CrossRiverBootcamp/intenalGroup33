using AutoMapper;
using Subscriber.Services.Models;
using Subscriber.WebApi.DTO;

namespace Subscriber.WebApi.Mapping
{
    public class CardMap : Profile
    {
        public CardMap()
        {
            CreateMap<CardModel, CardDTO>().IncludeMembers(c=>c.Subscriber);
            
        }
    }
}
