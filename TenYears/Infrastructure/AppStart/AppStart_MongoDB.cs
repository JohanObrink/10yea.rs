using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization;
using TenYears.Models;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System.Configuration;

namespace TenYears.Infrastructure.AppStart
{
    public class AppStart_MongoDB
    {
        public static void Start()
        {
            //var server = MongoServer.Create(ConfigurationManager.AppSettings["MONGOHQ_URL"]);

            BsonSerializer.RegisterIdGenerator(
                typeof(string),
                StringObjectIdGenerator.Instance
            );
            /*
            BsonClassMap.RegisterClassMap<TimelineEvent>(x =>
            {
                x.AutoMap();
                x.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<Person>(x =>
            {
                x.AutoMap();
                x.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
            });*/
        }
    }
}