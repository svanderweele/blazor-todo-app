using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoDemo.Shared
{
    public class TodoModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }


        public int AssigneeId { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
