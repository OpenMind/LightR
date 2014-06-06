using System;
using LightR.Common;
using LightR.Common.Formatter;

namespace LightR.Services
{
    public class LightROptions
    {
        #region LightR Services Api Headers

        public const string ServicesApiRequestHttpHeader = "X-ApiRequest";
        public const string ServicesApiModeHttpHeader = "X-ApiMode";

        #endregion

        #region LightR Services Api Constants

        public const string ServicesApiRequestSuffix = "Request";
        public const string ServicesApiResponseSuffix = "Response";

        #endregion


        public bool IntegrateInProcessing { get; set; }
        public AcceptVerbs DefaultAcceptVerb { get; private set; }
        public IContentFormatter DefaultFormatter { get; private set; }
        public IContentFormatter[] SpecifiedFormatters { get; private set; }

        public bool ParameterStringImplicitNullAsDefault { get; set; }
        public bool ParameterEnumAllowsFieldNameParse { get; set; }

        /// <summary>
        /// <pre>Use buffering when content formatter serialize, Default is BufferAndWrite.</pre>
        /// <pre>If you use top level stream buffering, set to DirectWrite for avoid double buffering.</pre>
        /// </summary>
        public StreamWriteOption StreamWriteOption { get; set; }

        public ErrorHandlingPolicy ErrorHandlingPolicy { get; set; }

        //public LightNodeFilterCollection Filters { get; private set; }

        public LightROptions(AcceptVerbs defaultAcceptVerb, IContentFormatter defaultFormatter, params IContentFormatter[] specifiedFormatters)
        {
            DefaultAcceptVerb = defaultAcceptVerb;
            DefaultFormatter = defaultFormatter;
            SpecifiedFormatters = specifiedFormatters;
            IntegrateInProcessing = false;
            ParameterStringImplicitNullAsDefault = false;
            ParameterEnumAllowsFieldNameParse = false;
            StreamWriteOption = StreamWriteOption.BufferAndWrite;
            ErrorHandlingPolicy = ErrorHandlingPolicy.ThrowException;
            //Filters = new LightNodeFilterCollection();
        }

        public LightROptions ConfigureWith(Action<LightROptions> @this)
        {
            @this(this);
            return this;
        }

        public string Url { get; set; }
        public ResolutionMode ResolutionMode { get; set; }

        public static bool IsRequest(Type messageType)
        {
            return messageType.Name.EndsWith(ServicesApiRequestSuffix);
        }
        public static bool IsResponse(Type messageType)
        {
            return messageType.Name.EndsWith(ServicesApiResponseSuffix);
        }

        public static string GetMessageName(IMessage message)
        {
            return GetMessageName(message.GetType());
        }

        public static string GetMessageName(Type messageType)
        {
            if (!typeof(IMessage).IsAssignableFrom(messageType))
                throw new ArgumentOutOfRangeException("messageType", string.Concat("The message type must derive from ", typeof(IMessage).Name));

            var suffix = messageType.Name.EndsWith(ServicesApiRequestSuffix)
                ? ServicesApiRequestSuffix
                : messageType.Name.EndsWith(ServicesApiRequestSuffix)
                    ? ServicesApiResponseSuffix
                    : string.Empty;

            return messageType.Name.Substring(0, messageType.Name.Length - suffix.Length);
        }
    }

    public enum ResolutionMode
    {
        Url = 1,
        Header
    }

    [Flags]
    public enum AcceptVerbs
    {
        Get = 1,
        Post = 2
    }

    public enum StreamWriteOption
    {
        BufferAndWrite = 0,
        BufferAndAsynchronousWrite = 1,
        DirectWrite = 2
    }

    public enum ErrorHandlingPolicy
    {
        /// <summary>Do Nothing, throw next pipeline.</summary>
        ThrowException = 0,
        /// <summary>Response StatusCode is 500.</summary>
        ReturnInternalServerError = 1,
        /// <summary>Response StatusCode is 500 and ResponseBody includes error details for debugging.</summary>
        ReturnInternalServerErrorIncludeErrorDetails = 2
    }
}