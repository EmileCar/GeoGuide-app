using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Domain
{
	[BsonIgnoreExtraElements]
	public class Region
    {
		[BsonElement("name")]
		public string Name { get; set; }
        [BsonId]
		[BsonRepresentation(BsonType.String)]
		public string Id { get; set; } = string.Empty;
    }
}
