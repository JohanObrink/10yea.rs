using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace TenYears.Services.MongoServices
{
    public class AMongoServiceBase<T> : TenYears.Services.IServiceBase<T>
    {
        protected readonly MongoDatabase database;
        protected readonly string collectionName;

        public AMongoServiceBase(MongoDatabase database)
        {
            this.database = database;
            this.collectionName = typeof(T).Name;
        }

        public virtual T Get(string id)
        {
            return Collection.FindOneByIdAs<T>(id);
        }

        public virtual T Save(T entity)
        {
            Collection.Save(entity);

            return entity;
        }



        /// <summary>
        /// Retrieves all TimelineEvents sorted by Date
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return Collection.FindAllAs<T>();
        }

        /// <summary>
        /// Deletes a TimelineEvent
        /// </summary>
        /// <param name="timelineEvent"></param>
        public virtual void Delete(string id)
        {
            Collection.Remove(Query.EQ("Id", id));
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