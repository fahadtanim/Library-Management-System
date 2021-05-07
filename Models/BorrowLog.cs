using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public enum BorrowStatus
    {
        Closed,
        Opened
    }
    public class BorrowLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("bookLogs")]
        public List<BookLog> BookLogs { get; set; }

        [BsonElement("borrowDate")]
        public DateTime BorrowDate { get; set; }

        [BsonElement("borrowStatus")]
        public BorrowStatus BorrowStatus { set; get; }

        [BsonElement("libraryId")]
        public string LibraryId { get; set; }
    }
}
