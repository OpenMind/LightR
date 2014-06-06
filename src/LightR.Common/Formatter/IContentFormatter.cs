using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightR.Common.Formatter
{
    public interface IContentFormatter
    {
        string MediaType { get; }
        string Ext { get; }
        Encoding Encoding { get; }
        void Serialize(Stream stream, object obj);
        object Deserialize(Type type, Stream stream);
    }
}
