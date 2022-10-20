using MediatR;

namespace CarConfigurator.Framework.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}