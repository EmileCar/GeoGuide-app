using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Domain
{
    [BsonIgnoreExtraElements]
    public class DrivingSide
    {
        [BsonId]
        public int DrivingSideId { get; set; }
        [BsonElement("side")]
        public string side { get; set; }
    }
}
