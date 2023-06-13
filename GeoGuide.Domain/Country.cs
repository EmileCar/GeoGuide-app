using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GeoGuide.Domain
{
    [BsonIgnoreExtraElements]
    public class Country
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("population")]
        public int Population { get; set; }
        [BsonElement("area")]
        public int Area { get; set; }
        [BsonElement("currency")]
        public string Currency { get; set; }
        [BsonElement("languages")]
        public List<Language> Languages { get; set; }
        [BsonElement("region")]
        public Region Region { get; set; }
        [BsonElement("flag")]
        public string Flag { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
    }
}