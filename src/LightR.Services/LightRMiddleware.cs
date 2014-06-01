using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace LightR.Services
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class LightRMiddleware
    {
        private readonly AppFunc _next;
        private readonly LightROptions _options;

        public LightRMiddleware(AppFunc next, LightROptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);


            if (_options.IntegrateInProcessing)
                await _next(environment).ConfigureAwait(false);
        }
    }
}
