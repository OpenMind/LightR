using LightR.Common;

namespace LightR.Services
{
    public abstract class ServiceHandler<TRequest, TResponse>
        where TRequest : IMessage
        where TResponse : IMessage
    {
        
    }

    public interface IServiceHandler<TRequest>
        where TRequest : IMessage
    {
        
    }
}