using Microsoft.Extensions.Configuration;
using Subscriber.Data.Entities;
using Subscriber.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Subscriber.Data.Data
{
   public class SubscriberData : ISubscriberData
    {
        private readonly IDbContextFactory<WeightDBContext> _factory;
        public SubscriberData(IDbContextFactory<WeightDBContext> factory)
        {
            _factory = factory;
        }
        public async Task AddSubscriber(SubscriberEntity subscriber)
        {
            using var context = _factory.CreateDbContext() ;
                await context.Subscribers.AddAsync(subscriber);
                await context.SaveChangesAsync();
        }
        public async Task AddCard(CardEntity card)
        {
            using var context = _factory.CreateDbContext();
                await context.Cards.AddAsync(card);
                await context.SaveChangesAsync();
        }
        public async Task<CardEntity> GetCardById(int id)
        {
            using var context = _factory.CreateDbContext();
                return await context.Cards.FirstOrDefaultAsync(c=>c.Id == id);
        }
        public async Task<bool> CheckUniqueEmail(string email)
        {
            using var context = _factory.CreateDbContext();
                SubscriberEntity subscriber = await context.Subscribers.FirstOrDefaultAsync(c => c.Email.Equals(email));
                return (subscriber == null) ? true : false;
        }
        public async Task<int?> ExistAndGetCardId(string email, string password)
        {
            using var context = _factory.CreateDbContext();
                var subscriber = await context.Subscribers.FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Password.Equals(password));
                CardEntity? card = (subscriber == null) ? null : await context.Cards.FirstAsync(c => c.SubscriberId.Equals(subscriber.Id)); 
                return card.Id;
        }
    }
}
