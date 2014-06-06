using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LightR.Common.Formatter
{
    public class DataContractJsonContentFormatter : ContentFormatterBase
    {
        public DataContractJsonContentFormatter(string mediaType = "application/json", string ext = "json")
            : base(mediaType, ext, Encoding.UTF8)
        {
        }

        public override void Serialize(Stream stream, object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType());
            serializer.WriteObject(stream, obj);
        }

        public override object Deserialize(Type type, Stream stream)
        {
            var serializer = new DataContractJsonSerializer(type);
            return serializer.ReadObject(stream);
        }
    }
}