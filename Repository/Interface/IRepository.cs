
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApiWithMongo.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        TEntity Get(ObjectId _id);

        IEnumerable<TEntity> List();

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        void Remove(TEntity obj);

        void Remove(ObjectId _id);
    }
}