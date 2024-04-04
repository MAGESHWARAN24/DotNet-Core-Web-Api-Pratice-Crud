using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
namespace MongodbWebApi.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [MaxLength(24)]
        public string Id { get; set; } = null!;
        [BsonElement("Task")]
        [BsonRequired]
        public string? TaskTittle { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } = "Pending";
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
