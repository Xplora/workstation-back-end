using Cortex.Mediator.Notifications;
using TripMatch.Xplore.Platform.Shared.Domain.Model.Events;

namespace TripMatch.Xplore.Platform.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}