using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SpeedTraps.DTO;

namespace SpeedTraps
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.irishspeedtraps.com/images/636046524329307506.jpg";
            StringBuilder output = new StringBuilder();


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList itemNodes = xmlDoc.SelectNodes("//markers/marker");

            foreach (XmlNode itemNode in itemNodes)
            {
                DTO.Marker marker = _parseMarker(itemNode);
                
            }
            /*
            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(url))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Name);
                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
                
            }
            */

        }

        private static Marker _parseMarker(XmlNode itemNode)
        {
            

            XmlNode titleNode = itemNode.SelectSingleNode("type");
            XmlNode dateNode = itemNode.SelectSingleNode("roadName");
            if ((titleNode != null) && (dateNode != null))
                Console.WriteLine(dateNode.InnerText + ": " + titleNode.InnerText);

            return new Marker();

           // throw new NotImplementedException();
        }
    }
}
