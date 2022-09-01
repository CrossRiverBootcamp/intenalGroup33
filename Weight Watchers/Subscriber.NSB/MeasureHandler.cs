using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Subscriber.NSB;
public class MeasureHandler :
    IHandleMessages<MeasureDataAdded>
{
    static ILog log = LogManager.GetLogger<MeasureHandler>();

    public Task Handle(MeasureDataAdded message, IMessageHandlerContext context)
    {
        log.Info("Message received at endpoint");
        return Task.CompletedTask;
    }
}