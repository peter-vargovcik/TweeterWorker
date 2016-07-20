using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTraps.DTO
{
    public class Marker
    {
        int ID { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string Type { get; set; }
        string County { get; set; }
        string RoadName { get; set; }
        string RoadNumber { get; set; }
        int SpeedLimit { get; set; }
        string Direction { get; set; }
        string Details { get; set; }
        DateTime Date { get; set; }
    }

    /*
    <marker 
        id = "147" 
        lat="53.56249" 
        lng="-6.44285" 
        type="Static Camera (Gatso)" 
        county="Meath" 
        roadName="Ashbourne-Slane" 
        roadNumber="N2" 
        limit="100" 
        direction="South" 
        details="Fixed camera about 5km north of ashbourne. Between Kilmoon Cross (Junction with R153 Drogheda Rd) and Statoil garage Coolfore." 
        date="3/30/2007" 
        time="10:30" 
    />
    */
}
