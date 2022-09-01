using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Entities
{
    public class CardEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SubscriberEntity")]
        public string SubscriberId { get; set; }
        public SubscriberEntity Subscriber { get; set; }
        public DateTime OpenDate { get; set; }
        public float BMI { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
