using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class TrackingUpdated :IEvent
    {
        public string MeasureId { get; set; }
        public SubscriberStatus Status { get; set; }
    }
}
