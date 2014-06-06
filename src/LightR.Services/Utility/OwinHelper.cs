using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace LightR.Services.Utility
{
    internal static class OwinHelper
    {
        private const string OwinResponseBodyKey = "owin.ResponseBody";
        private const string OwinResponseStatusCodeKey = "owin.ResponseStatusCode";

        public static void EmitStringMessage(this IDictionary<string, object> environment, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            (environment[OwinResponseBodyKey] as Stream).Write(bytes, 0, bytes.Length);
        }

        public static void EmitOK(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.OK; // 200
        }

        public static void EmitNoContent(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.NoContent; // 204
        }

        public static void EmitBadRequest(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.BadRequest; // 400
        }

        public static void EmitNotFound(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.NotFound; // 404
        }

        public static void EmitMethodNotAllowed(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.MethodNotAllowed; // 405
        }

        public static void EmitNotAcceptable(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.NotAcceptable; // 406
        }

        public static void EmitUnsupportedMediaType(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.UnsupportedMediaType; // 415
        }

        public static void EmitInternalServerError(this IDictionary<string, object> environment)
        {
            environment[OwinResponseStatusCodeKey] = (int)System.Net.HttpStatusCode.InternalServerError; // 500
        }
    }
}