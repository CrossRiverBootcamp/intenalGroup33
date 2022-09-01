using AutoMapper;
using Subscriber.Data.Entities;
using Subscriber.Data.Interfaces;
using Subscriber.Services.Interfaces;
using Subscriber.Services.Mapping;
using Subscriber.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services.Services
{
    public class SubscriberService:ISubscriberService
    {
        ISubscriberData _subscriberData;
        IMapper _mapper;
        public SubscriberService(ISubscriberData subscriberData)
        {
            _subscriberData = subscriberData;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SubscriberMapToEntity>();
            });
            _mapper = config.CreateMapper();
        }

        public async Task<bool> AddSubscriberAndCard(float height, SubscriberModel suscriberModel)
        {
            try
            {
                SubscriberEntity subscriber = _mapper.Map<SubscriberEntity>(suscriberModel);
                subscriber.Id = Guid.NewGuid().ToString();
                if (!await _subscriberData.CheckUniqueEmail(subscriber.Email))
                {
                    return false;
                }
                /////////Transaction doesnt work////////
                //await _subscriberData.AddSubscriber(subscriber);
                CardEntity card = new CardEntity();
                card.BMI = 0;
                card.Height = height;
                card.Subscriber = subscriber;
                card.SubscriberId = subscriber.Id;
                card.OpenDate = DateTime.Now;
                await _subscriberData.AddCard(card);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int?> Login(string email, string password)
        {
            try
            {
               return await _subscriberData.ExistAndGetCardId(email, password);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
