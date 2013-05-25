using System.IO;

namespace XMLNativeSerializerSample.util.xml
{
    interface IXmlSerializable
    {
        void Serialize(Stream stream);
    }
}
