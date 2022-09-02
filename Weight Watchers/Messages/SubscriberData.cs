using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class SubscriberData: ContainSagaData
    {
        public string MeasureId { get; set; }
        public bool IsBMIUpdated { get; set; }
        public bool IsTrackingUpdated { get; set; }
    }
}
