using System;
using System.IO;
using System.Text;

namespace LightR.Common.Formatter
{
    public abstract class ContentFormatterBase : IContentFormatter
    {
        protected ContentFormatterBase(string mediaType, string ext, Encoding encoding)
        {
            this.MediaType = mediaType;
            this.Ext = ext;
            this.Encoding = encoding;
        }

        public string MediaType { get; private set; }

        public string Ext { get; private set; }

        public Encoding Encoding { get; private set; }

        public abstract void Serialize(Stream stream, object obj);

        public abstract object Deserialize(Type type, Stream stream);
    }
}