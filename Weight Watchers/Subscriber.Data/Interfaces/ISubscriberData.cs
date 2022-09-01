using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Interfaces
{
    public interface ISubscriberData
    {
        Task AddSubscriber(SubscriberEntity subscriber);
        Task AddCard(CardEntity card);
        Task<bool> CheckUniqueEmail(string email);
        Task<int?> ExistAndGetCardId(string email, string password);
    }
}
