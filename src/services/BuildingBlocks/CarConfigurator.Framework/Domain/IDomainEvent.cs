using MediatR;

namespace CarConfigurator.Framework.Domain;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}