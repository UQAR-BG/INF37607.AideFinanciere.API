using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class BackEndSystemService : IBackEndSystemService
    {
        public async Task sendRequestToBackEnd(Request request, string directory)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns0", "http://EAISolution.Request");

            string xml = XmlTranfromHelper.Serialize(request, namespaces);

            await File.WriteAllTextAsync(directory + "Request" + DateTime.Now.Ticks + ".xml", xml);

        }
    }
}
