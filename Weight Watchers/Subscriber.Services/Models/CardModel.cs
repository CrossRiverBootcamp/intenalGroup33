using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public SubscriberModel Subscriber { get; set; }
        public DateTime OpenDate { get; set; }
        public float BMI { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
