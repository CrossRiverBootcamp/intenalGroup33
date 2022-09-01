using Subscriber.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services.Interfaces
{
    public interface ISubscriberService
    {
        Task<bool> AddSubscriberAndCard(float height, SubscriberModel suscriberModel);
        Task<int?> Login(string email, string password);
    }
}
