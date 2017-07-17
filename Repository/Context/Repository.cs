

using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApiWithMongo.Repository
{

    public class Repository<TEntity> where TEntity : class
    {
        protected WebApiWithMongoContext _context;

        public Repository(WebApiWithMongoContext context)
        {
            _context = context;
        }
    }



}