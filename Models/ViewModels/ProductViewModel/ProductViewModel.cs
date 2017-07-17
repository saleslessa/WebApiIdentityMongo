

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiWithMongo.Models
{
    public class ProductViewModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public virtual ObjectId _id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage="Name must have less than 150 characters")]
        public string name {get;set;}

        [Required]
        public double price {get;set;}

        public virtual Brand brand {get;set;}

        public virtual List<Category> categories{get;set;}

    }
}