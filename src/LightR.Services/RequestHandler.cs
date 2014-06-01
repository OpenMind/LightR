using LightR.Common;

namespace LightR.Services
{
    public abstract class RequestHandler<TRequest, TREsponse>
        where TRequest : IMessage
        where TREsponse : IMessage
    {
        
    }
}