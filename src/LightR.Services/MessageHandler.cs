using System.Threading.Tasks;
using Microsoft.Owin;

namespace LightR.Services
{
    public class MessageHandler
    {
        private readonly LightROptions _options;

        public MessageHandler(LightROptions options)
        {
            _options = options;
        }

        public async Task<OwinContext> ProcessMessage(OwinContext input)
        { 
            return await Task.FromResult(input);
        }
    }
}