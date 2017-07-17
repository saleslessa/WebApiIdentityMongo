using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiWithMongo.Models
{

    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public virtual ObjectId _id { get; set; }

        [Required]
        [MaxLength(150)]
        public string name {get;set;}

        [Required]
        public double price {get;set;}

        public virtual Brand brand {get;set;}

        public virtual List<Category> categories{get;set;}


        public Product() {
            this._id = ObjectId.GenerateNewId();
        }

        public bool isValid()
        {
            return (name != null && name.Trim().Length > 0) && (price > 0);
        }
    }

}