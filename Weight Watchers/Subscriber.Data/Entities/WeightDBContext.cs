using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Entities
{
    public class WeightDBContext: DbContext
    {
        public WeightDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SubscriberEntity> Subscribers { get; set; }
        public DbSet<CardEntity> Cards { get; set; }
    }
}
