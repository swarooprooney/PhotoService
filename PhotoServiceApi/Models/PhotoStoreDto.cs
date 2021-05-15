using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PhotoServiceApi.Models
{
    public class PhotoStoreDto
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}