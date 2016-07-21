using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SpeedTraps.DTO;
using System.Globalization;

namespace SpeedTraps
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.irishspeedtraps.com/images/636046524329307506.jpg";
            List<Marker> markers = new List<Marker>();
            

            //second version

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList itemNodes = xmlDoc.SelectNodes("//markers/marker");

            foreach (XmlNode itemNode in itemNodes)
            {
                markers.Add(_parseMarker(itemNode));
                
            }

            var recent = markers.Where(x => x.Date.Year > 2010).ToList();

        }

        private static Marker _parseMarker(XmlNode itemNode)
        {


            //XmlNode titleNode = itemNode.Attributes["type"];
            //XmlNode dateNode = itemNode.Attributes["roadNumber"];
            //if ((titleNode != null) && (dateNode != null))
            //    Console.WriteLine(dateNode.InnerText + ": " + titleNode.InnerText);


            DateTime parsedDate;
            var pattern = "M/d/yyyy-HH:mm";
            var timeString = itemNode.Attributes["time"].Value;

            var dateValue = itemNode.Attributes["date"].Value.Split(' ')[0] + "-" + ((timeString.Length == 5) ? timeString : "00:00");

            DateTime.TryParseExact(dateValue, pattern, null, DateTimeStyles.None, out parsedDate);

            return new Marker()
            {
                ID = int.Parse(itemNode.Attributes["id"].Value),
                Latitude = double.Parse(itemNode.Attributes["lat"].Value),
                Longitude = double.Parse(itemNode.Attributes["lng"].Value),
                Type = itemNode.Attributes["type"].Value,
                County = itemNode.Attributes["county"].Value,
                RoadName = itemNode.Attributes["roadName"].Value,
                RoadNumber = itemNode.Attributes["roadNumber"].Value,
                SpeedLimit = int.Parse(itemNode.Attributes["limit"].Value),
                Direction = itemNode.Attributes["direction"].Value,
                Details = itemNode.Attributes["details"].Value,
                Date = parsedDate
            };
            
        }
    }
}
