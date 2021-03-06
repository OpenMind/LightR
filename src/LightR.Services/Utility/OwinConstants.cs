namespace LightR.Services.Utility
{

    /// <summary>
    /// Owin Spec 1.0.0
    //  http://owin.org/spec/owin-1.0.0.html
    /// </summary>
    internal static class OwinConstants
    {
        // 3.2.1 Request Data
        public const string RequestBody = "owin.RequestBody";
        public const string RequestHeaders = "owin.RequestHeaders";
        public const string RequestMethod = "owin.RequestMethod";
        public const string RequestPath = "owin.RequestPath";
        public const string RequestPathBase = "owin.RequestPathBase";
        public const string RequestProtocol = "owin.RequestProtocol";
        public const string RequestQueryString = "owin.RequestQueryString";
        public const string RequestScheme = "owin.RequestScheme";

        // 3.2.2 Response Data
        public const string ResponseBody = "owin.ResponseBody";
        public const string ResponseHeaders = "owin.ResponseHeaders";
        public const string ResponseStatusCode = "owin.ResponseStatusCode";
        public const string ResponseReasonPhrase = "owin.ResponseReasonPhrase";
        public const string ResponseProtocol = "owin.ResponseProtocol";

        // 3.2.3 Other Data
        public const string Version = "owin.Version";
        public const string CallCancelled = "owin.CallCancelled";
    }
}