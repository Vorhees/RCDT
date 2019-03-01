using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RCDT.Models
{
    public class AdminUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("isResearcher")]
        public bool isResearcher { get; set; }
        
    }
}