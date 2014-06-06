using System;
using System.IO;
using System.Text;

namespace LightR.Common.Formatter
{
    public class XmlContentFormatter : ContentFormatterBase
    {
        public XmlContentFormatter(string mediaType = "application/xml", string ext = "xml")
            : base(mediaType, ext, Encoding.UTF8)
        {
        }

        public override void Serialize(Stream stream, object obj)
        {
            new System.Xml.Serialization.XmlSerializer(obj.GetType()).Serialize(stream, obj);
        }

        public override object Deserialize(Type type, Stream stream)
        {
            return new System.Xml.Serialization.XmlSerializer(type).Deserialize(stream);
        }
    }
}