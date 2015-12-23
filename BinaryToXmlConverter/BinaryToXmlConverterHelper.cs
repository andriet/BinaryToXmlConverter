using System.Text;
using System.IO;
using System.Xml;

namespace BinaryToXmlConverter
{
    public class BinaryToXmlConverterHelper
    {
        public string ConvertToXmlWithBase64(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xw = XmlWriter.Create(sb))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("serializedBinary");
                xw.WriteAttributeString("types", "dt", "urn:schemas-microsoft-com:datatypes", "bin.base64");
                byte[] b = File.ReadAllBytes(fileName);
                xw.WriteBase64(b, 0, b.Length);
                xw.WriteEndElement();
                xw.WriteEndDocument();
            }
            return sb.ToString();
        }

        public string ConvertToBase64(string fileName)
        {
            byte[] b = File.ReadAllBytes(fileName);
            return System.Convert.ToBase64String(b);
        }

        public void SaveBase64AsFile(string base64Source, string destFileName)
        {
            byte[] bytes = System.Convert.FromBase64String(base64Source);
            using (FileStream fs = new FileStream(destFileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
