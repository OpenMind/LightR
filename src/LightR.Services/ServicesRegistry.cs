using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LightR.Common;

namespace LightR.Services
{
    public class ServicesRegistry : IServicesRegistry
    {
        private readonly IDictionary<Type, Type> _mappings;
        private readonly IDictionary<string, Type> _requestMappings;
        private readonly IDictionary<string, Type> _responseMappings;
        private readonly IList<Type> _services;

        public ServicesRegistry()
        {
            _mappings = new Dictionary<Type, Type>();
            _requestMappings = new Dictionary<string, Type>();
            _responseMappings = new Dictionary<string, Type>();
            _services = new List<Type>();
            //MessageHandlerType = typeof(IMessageHandler);
            OpenMessageHandlerType = typeof(IServiceHandler<>);
        }


        public Type OpenMessageHandlerType { get; private set; }
        public Type MessageHandlerType { get; private set; }
        public Type GetRequest(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Type> GetRequestAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Type GetRequestHandlerFor(IMessage request)
        {
            throw new NotImplementedException();
        }

        public async Task<Type> GetRequestHandlerForAsync(IMessage request)
        {
            throw new NotImplementedException();
        }

        public Type GetResponse(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Type> GetResponseAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Type GetResponseTypeFor(IMessage request)
        {
            throw new NotImplementedException();
        }

        public async Task<Type> GetResponseTypeForAsync(IMessage request)
        {
            throw new NotImplementedException();
        }

        public Type GetRequestTypeFor(IMessage request)
        {
            throw new NotImplementedException();
        }

        public async Task<Type> GetRequestTypeForAsync(IMessage request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> GetServices()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Type>> GetServicesAsync()
        {
            throw new NotImplementedException();
        }
    }
}