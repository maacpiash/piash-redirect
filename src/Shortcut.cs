using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Redirect
{
    public class Shortcut
    {
        public static int MaxLength = 6;
        
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("RealUrl")]
        public string RealUrl { get; set; }

        private string shortKey;
        
        [BsonElement("ShortKey")]
        public string ShortKey
        {
            get => shortKey;
            set => shortKey = value.Length > MaxLength ? value.Substring(0, MaxLength) : value;
        }
    }
}
