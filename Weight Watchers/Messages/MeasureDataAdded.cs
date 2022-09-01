using NServiceBus;

namespace Messages
{
    public class MeasureDataAdded
    {
        public string MeasureId { get; set; }
        public int CardId { get; set; }
        public float Weight { get; set; }
    }
}