using System;
using System.IO;

namespace LightR.Common.Formatter
{
    public class RawOctetStreamContentFormatter : ContentFormatterBase
    {
        public RawOctetStreamContentFormatter(string mediaType = "application/octet-stream", string ext = "")
            : base(mediaType, ext, null)
        {

        }

        public override void Serialize(Stream stream, object obj)
        {
            var bytes = obj as byte[];
            if (bytes != null)
            {
                stream.Write(bytes, 0, bytes.Length);
                return;
            }
            throw new InvalidOperationException();
        }

        public override object Deserialize(Type type, Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}