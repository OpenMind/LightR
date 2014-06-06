using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LightR.Common;

namespace LightR.Services
{
    public interface IServicesRegistry
    {
        Type OpenMessageHandlerType { get; }
        Type MessageHandlerType { get; }
        Type GetRequest(string name);
        Task<Type> GetRequestAsync(string name);
        Type GetRequestHandlerFor(IMessage request);
        Task<Type> GetRequestHandlerForAsync(IMessage request);
        Type GetResponse(string name);
        Task<Type> GetResponseAsync(string name);
        Type GetResponseTypeFor(IMessage request);
        Task<Type> GetResponseTypeForAsync(IMessage request);
        Type GetRequestTypeFor(IMessage request);
        Task<Type> GetRequestTypeForAsync(IMessage request);
        IEnumerable<Type> GetServices();
        Task<IEnumerable<Type>> GetServicesAsync();
    }
}