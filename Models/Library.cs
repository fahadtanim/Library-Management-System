using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public class Library
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("phone")]
        public string Phone { get; set; }
        
        [BsonElement("password")]
        public string Password { get; set; }
    }
}
