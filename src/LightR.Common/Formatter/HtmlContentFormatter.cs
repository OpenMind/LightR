using System.Text;

namespace LightR.Common.Formatter
{
    public class HtmlContentFormatter : TextContentFormatter
    {
        public HtmlContentFormatter(string mediaType = "text/html", string ext = "htm|html")
            : this(Encoding.UTF8, mediaType, ext)
        {

        }

        public HtmlContentFormatter(Encoding encoding, string mediaType = "text/html", string ext = "htm|html")
            : base(encoding, mediaType, ext)
        {
        }
    }
}