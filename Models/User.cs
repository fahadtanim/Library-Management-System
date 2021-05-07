using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("phone")]
        public string Phone { get; set; }
        [BsonElement("dateOfBirth")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("libraryId")]
        public string LibraryId { get; set; }
    }
}
