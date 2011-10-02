using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace TenYears.Services.MongoServices
{
    public class AMongoServiceBase<T>
    {
        protected readonly MongoDatabase database;
        protected readonly string collectionName;

        public AMongoServiceBase(MongoDatabase database)
        {
            this.database = database;
            this.collectionName = typeof(T).Name;
        }

        protected MongoCollection<T> Collection
        {
            get
            {
                return database.GetCollection<T>(collectionName);
            }
        }
    }
}