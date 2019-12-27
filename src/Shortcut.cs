using MongoDB.Bson;
using MongoDB.Driver;

namespace Redirect
{
    public class Shortcut
    {
        public static int MaxLength = 6;
        public ObjectId Id { get; set; }
        public string RealUrl { get; set; }

        private string shortKey;
        public string ShortKey
        {
            get => shortKey;
            set => shortKey = value.Length > MaxLength ? value.Substring(0, MaxLength) : value;
        }
    }
}
