using MongoDB.Bson.Serialization.Attributes;

namespace React_and_WebAPI.Models
{
    [BsonIgnoreExtraElements]
    public class People
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string? Name { get; set; } 
        [BsonElement("country")]
        public string? Country { get; set; }
        [BsonElement("annual_income")]
        public float AnnualIncome { get; set; }
        [BsonElement("email_list")]
        public List<string>? EmailIdsList { get; set; }
    }
}
