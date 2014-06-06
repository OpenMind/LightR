using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace LightR.Common.Formatter
{
    public class JsonContentFormatter : ContentFormatterBase
    {
        public JsonContentFormatter(string mediaType = "application/json", string ext = "json")
            : base(mediaType, ext, Encoding.UTF8)
        {}


        public override void Serialize(Stream stream, object obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            var bytes = Encoding.GetBytes(result);
            stream.Write(bytes, 0, bytes.Length);
        }

        public override object Deserialize(Type type, Stream stream)
        {
            using (var sr = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
            {
                return JsonConvert.DeserializeObject(sr.ReadToEnd(), type);
            }
        }
    }
}