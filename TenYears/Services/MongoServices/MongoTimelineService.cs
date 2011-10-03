using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenYears.Models;
using MongoDB.Driver;
using FluentMongo;
using MongoDB.Driver.Builders;

namespace TenYears.Services.MongoServices
{
    /// <summary>
    /// Service for managing TimelineEvents
    /// </summary>
    public class MongoTimelineService : AMongoServiceBase<TimelineEvent>, ITimelineService
    {
        public MongoTimelineService (MongoDatabase database) : base(database)
        {
        }

        public override IEnumerable<TimelineEvent> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Date);
        }
    }
}