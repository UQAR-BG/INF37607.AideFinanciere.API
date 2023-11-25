using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EAISolutionFrontEnd.Infrastructure
{
    class XmlTranfromHelper
    {
        public static string Serialize<T>(T toSerialize, XmlSerializerNamespaces namespaces)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, toSerialize, namespaces);
                    return textWriter.ToString();
                }
            }
        }
    }
}
