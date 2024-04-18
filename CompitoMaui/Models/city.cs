using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoMaui.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Coordinate
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class MetadataCity
    {
        public string id { get; set; }
        public bool @private { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
    }

    public class RecordCity
    {
        public string Stato { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public string Sindaco { get; set; }
        public Coordinate Coordinate { get; set; }
        public int Altitudine { get; set; }
        public string Superficie { get; set; }
        public string Abitanti { get; set; }
        public string Densit { get; set; }
        public string Stemma { get; set; }
    }

    public class CityResults
    {
        public RecordCity record { get; set; }
        public MetadataCity metadata { get; set; }
    }


}
