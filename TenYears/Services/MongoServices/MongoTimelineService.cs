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

        /// <summary>
        /// Retrieves a single TimelineEvent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TimelineEvent Get(string id)
        {
            return Collection.FindOneByIdAs<TimelineEvent>(id);
        }

        /// <summary>
        /// Retrieves all TimelineEvents sorted by Date
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TimelineEvent> GetAll()
        {
            return Collection.FindAllAs<TimelineEvent>();
        }

        /// <summary>
        /// Inserts or Updates a TimelineEvent
        /// </summary>
        /// <param name="timelineEvent"></param>
        /// <returns></returns>
        public TimelineEvent Save(TimelineEvent timelineEvent)
        {
            Collection.Save(timelineEvent);

            return timelineEvent;
        }

        /// <summary>
        /// Deletes a TimelineEvent
        /// </summary>
        /// <param name="timelineEvent"></param>
        public void Delete(TimelineEvent timelineEvent)
        {
            Collection.Remove(Query.EQ("Id", timelineEvent.Id));
        }
    }
}