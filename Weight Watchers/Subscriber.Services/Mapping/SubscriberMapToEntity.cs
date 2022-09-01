using AutoMapper;
using Subscriber.Data.Entities;
using Subscriber.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services.Mapping
{
    public class SubscriberMapToEntity:Profile
    {
        public SubscriberMapToEntity()
        {
            CreateMap<SubscriberModel,SubscriberEntity>().ReverseMap();
        }
        
    }
}
