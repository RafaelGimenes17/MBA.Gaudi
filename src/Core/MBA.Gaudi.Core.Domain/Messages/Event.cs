using MediatR;

namespace MBA.Gaudi.Core.Domain.Messages;

public class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}