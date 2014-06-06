using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace LightR.Common.Formatter
{
    public class DataContractContentFormatter : ContentFormatterBase
    {
        public DataContractContentFormatter(string mediaType = "application/xml", string ext = "xml")
            : base(mediaType, ext, Encoding.UTF8)
        {
        }

        public override void Serialize(Stream stream, object obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            serializer.WriteObject(stream, obj);
        }

        public override object Deserialize(Type type, Stream stream)
        {
            var serializer = new DataContractSerializer(type);
            return serializer.ReadObject(stream);
        }
    }
}