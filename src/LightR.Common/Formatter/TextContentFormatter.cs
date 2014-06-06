using System;
using System.IO;
using System.Text;

namespace LightR.Common.Formatter
{
    public class TextContentFormatter : ContentFormatterBase
    {
        public TextContentFormatter(string mediaType = "text/plain", string ext = "txt")
            : this(Encoding.UTF8, mediaType, ext)
        {

        }

        public TextContentFormatter(Encoding encoding, string mediaType = "text/plain", string ext = "txt")
            : base(mediaType, ext, encoding)
        {
        }

        public override void Serialize(Stream stream, object obj)
        {
            var str = obj as string;
            if (str != null)
            {
                var bytes = Encoding.GetBytes(str);
                stream.Write(bytes, 0, bytes.Length);
                return;
            }
            throw new InvalidOperationException();
        }

        public override object Deserialize(Type type, Stream stream)
        {
            using (var sr = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
            {
                return sr.ReadToEnd();
            }
        }
    }
}