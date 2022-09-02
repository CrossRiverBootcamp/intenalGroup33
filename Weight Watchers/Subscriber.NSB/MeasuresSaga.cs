using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;
using Subscriber.Services.Services;

namespace Subscriber.NSB;
public class MeasuresSaga : Saga<SubscriberData>,
    IAmStartedByMessages<MeasureDataAdded>, IHandleMessages<TrackingUpdated>
{
    static ILog log = LogManager.GetLogger<MeasuresSaga>();
    static SubscriberStatusUpdated subscriber = new SubscriberStatusUpdated();
    private readonly SubscriberService _subscriberService;
    public MeasuresSaga(SubscriberService subscriberService)
    {
        _subscriberService = subscriberService;
    }
    public async Task Handle(MeasureDataAdded message, IMessageHandlerContext context)
    {
        float BMI = await _subscriberService.updateBMI(message);
        if(BMI > 0)
        {
            //log.Info($"Received OrderBilled, OrderId = {message.OrderId}");
            this.Data.IsBMIUpdated = true;
            BMIDTO newBMI = new()
            {
                MeasureId = message.MeasureId,
                BMI = BMI,
                CardId = message.CardId,
                Weight = message.Weight
            };
            await context.Publish(newBMI);
            //here I publish in order to catch it in the tracking? 
            //and then the tracking sends publish that is caught back down here
            //and thats how this sags is finished.
        }
        else
        {
            //send to error que
            Data.IsBMIUpdated = false;
        }
        await ProccessMeasure(context);
    }

    public async Task Handle(TrackingUpdated message, IMessageHandlerContext context)
    {
        if(message.Status == SubscriberStatus.Succeeded)
        {
            Data.IsTrackingUpdated = true;
        }
        else
        {
            //send to error que
            Data.IsTrackingUpdated = false;
        }
        await ProccessMeasure(context);
    }

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SubscriberData> mapper)
    {
        mapper.MapSaga(saga => saga.MeasureId)
            .ToMessage<MeasureDataAdded>(message => message.MeasureId)
            .ToMessage<TrackingUpdated>(message => message.MeasureId);
    }
    private async Task ProccessMeasure(IMessageHandlerContext context)
    {
        if(Data.IsBMIUpdated && Data.IsTrackingUpdated)
        {
            subscriber.Status = SubscriberStatus.Succeeded;
            await context.Publish(subscriber);
            MarkAsComplete();
        }
    }
}