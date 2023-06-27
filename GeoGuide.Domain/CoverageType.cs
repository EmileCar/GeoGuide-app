using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace GeoGuide.Domain
{
    [BsonIgnoreExtraElements]
    public class CoverageType
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CoverageId { get; set; } = String.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;

    }
}
