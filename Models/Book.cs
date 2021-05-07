using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace LibraryManagementSystem.Models
{
    
    public enum BookCategory{
        [EnumMember(Value = "CS")]
        CS,
        [EnumMember(Value = "EEE")]
        EEE,
        [EnumMember(Value = "ME")]
        ME,
        [EnumMember(Value = "PHILOSOPHY")]
        PHILOSOPHY,
        [EnumMember(Value = "LITERATURE")]
        LITERATURE
    }
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        
        [BsonElement("priceForLoosing")]
        public decimal Price { get; set; }

        [BsonElement("category")]

        public BookCategory Category { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }
        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("libraryId")]
        public string LibraryId { get; set; }
    }
}
