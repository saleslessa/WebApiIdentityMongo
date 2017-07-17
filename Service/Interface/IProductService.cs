
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using WebApiWithMongo.Models;

namespace WebApiWithMongo.Service
{
    public interface IProductService
    {
        void Add(ProductViewModel _product);

        void Update(ProductViewModel _product);

        void Remove(ProductViewModel _product);

        IEnumerable<ProductViewModel> List();

        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate);

        ProductViewModel Get(ObjectId _id);

        IEnumerable<Category> ListCcategories(Category _category);

        IEnumerable<Brand> ListBrands(Brand _brand);
    }
}