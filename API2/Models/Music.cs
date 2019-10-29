using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace API2.Models
{
    public class Music
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Title")]
        [JsonProperty("Title")]
        public string MusicTitle { get; set; }
        public string Group { get; set; }
        public int Year { get; set; }
        public string Platform { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}