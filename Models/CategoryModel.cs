using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiWithMongo.Models
{
    public class Category
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }

        [Required]
        public string name{get;set;}

        public bool isValid()
        {
            return name != null && name.Trim().Length > 0;
        }
    }
}