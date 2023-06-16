using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ThirdParty.Json.LitJson;
using Newtonsoft.Json;

namespace GeoGuide.Domain
{
    [BsonIgnoreExtraElements]
    public class Country
    {
        // Country specific fields
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CountryCode { get; set; } = String.Empty;

        [BsonElement("name")]
        [BsonIgnoreIfNull]
        public string Name { get; set; } = String.Empty;

        [BsonElement("population")]
        [BsonIgnoreIfDefault]
        public int? Population { get; set; }

        [BsonElement("area")]
        [BsonIgnoreIfDefault]
        public int? Area { get; set; }

        [BsonElement("independent")]
        [BsonIgnoreIfDefault]
        public bool? Independent { get; set; }

        [BsonElement("capital")]
        [BsonIgnoreIfNull]
        public string Capital { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }

        // Country options
        [BsonElement("drivingSide")]
        [BsonIgnoreIfNull]
        public DrivingSide? DrivingSide { get; set; }
        [BsonElement("coverage")]
        [BsonIgnoreIfNull]
        public Coverage? Coverage { get; set; }
		[BsonElement("region")]
		[BsonIgnoreIfNull]
		public Region? Region { get; set; }
	}
}