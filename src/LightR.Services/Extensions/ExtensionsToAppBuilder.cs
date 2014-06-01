using System.Reflection;
using Owin;

namespace LightR.Services.Extensions
{
    public static class ExtensionsToAppBuilder
    {
        public static void MapLightR(this IAppBuilder appBuilder)
        {
            appBuilder.Use(typeof (LightRMiddleware));
        }

        public static void MapLightR(this IAppBuilder appBuilder, LightROptions options)
        {
            
        }

        public static void MapLightR(this IAppBuilder appBuilder, LightROptions options,
            params Assembly[] hostAssemblies)
        {
            
        }
    }
}