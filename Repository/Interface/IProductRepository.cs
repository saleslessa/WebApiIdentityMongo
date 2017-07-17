

using System.Collections.Generic;
using WebApiWithMongo.Models;

namespace WebApiWithMongo.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Category> ListCcategories(Category _category);

        IEnumerable<Brand> ListBrands(Brand _brand);
    }
}