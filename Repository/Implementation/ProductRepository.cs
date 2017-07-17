using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiWithMongo.Models;

namespace WebApiWithMongo.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
         protected IMongoCollection<Product> _collection { get; }  

         private const string _collectionName = "Product";

        public ProductRepository(WebApiWithMongoContext context)
            :base(context)
        {
             _collection = _context.database.GetCollection<Product>(_collectionName);
             if(_collection == null)
             {
                _context.database.CreateCollection(_collectionName);
                _collection = _context.database.GetCollection<Product>(_collectionName);
             }
        }

        public Product Get(ObjectId _id)
        {
            return _collection.Find(p => p._id == _id).FirstOrDefault();
        }

        public void Insert(Product obj)
        {
            _collection.InsertOne(obj);
        }

        public IEnumerable<Product> List()
        {
            return _collection.Find(p => true).ToList();
        }

        public void Remove(Product obj)
        {
            _collection.DeleteOne(p => p == obj);
        }

        public void Remove(ObjectId _id)
        {
            _collection.DeleteOne(p => p._id == _id);
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }

        public void Update(Product obj)
        {
            _collection.ReplaceOne(p => p._id == obj._id, obj);
        }

        public IEnumerable<Category> ListCcategories(Category _category)
        {
            return this.Search(p => p.categories.Any(f => f == _category))
                    .Select(s => s.categories)
                    .Select(s => s.First());
        }

        public IEnumerable<Brand> ListBrands(Brand _brand)
        {
            var products = this.Search(p => p.brand == _brand);
            return products.GroupBy(p => p.brand)
                .Select(s => s.First())
                .Select(s => s.brand);
        }
    }
}