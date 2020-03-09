using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Modelle
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        
        public string blockeduri { get; set; }
        
        public string documenturi { get; set; }
        
        public string originalpolicy { get; set; }
        
        public string referrer { get; set; }
        
        public string sourcefile { get; set; }
        [BsonElement("Violation")]
        public string violateddirective { get; set; }
    }
}
