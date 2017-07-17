using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApiWithMongo.Models;
using MongoDB.Bson;
using WebApiWithMongo.Repository;
using AutoMapper;

namespace WebApiWithMongo.Service
{
    public class ProductService : IProductService
    {

        IProductRepository _repository;

        private readonly IMapper _mapper;
        
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public void Add(ProductViewModel _product)
        {
            try
            {
                var product = Mapper.Map<ProductViewModel, Product>(_product);
                _repository.Insert(product);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ProductViewModel Get(ObjectId _id)
        {
            return _mapper.Map<Product, ProductViewModel>(_repository.Get(_id));
            
        }

        public IEnumerable<ProductViewModel> List()
        {
            var list = _repository.List().ToList();
            return _mapper.Map<List<Product>, List<ProductViewModel>>(list);
        }

        public IEnumerable<Brand> ListBrands(Brand _brand)
        {
            try
            {
                return _repository.ListBrands(_brand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Category> ListCcategories(Category _category)
        {
            try 
            {
                return _repository.ListCcategories(_category);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Remove(ProductViewModel _product)
        {
            try 
            {
                _repository.Remove(_mapper.Map<ProductViewModel, Product>(_product));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_repository.Search(predicate));
        }

        public void Update(ProductViewModel _product)
        {
            try 
            {
                _repository.Update(_mapper.Map<ProductViewModel, Product>(_product));
            }
            catch(Exception)
            {
                throw;
            }
        }
    }

}