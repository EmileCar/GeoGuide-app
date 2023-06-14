using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Domain
{
    [BsonIgnoreExtraElements]
    public class Coverage
    {
        [BsonId]
        public int CoverageId { get; set; }
        [BsonElement("coverage")]
        public string type { get; set; }
    }
}
