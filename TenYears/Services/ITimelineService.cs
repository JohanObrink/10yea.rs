using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenYears.Models;

namespace TenYears.Services
{
    /// <summary>
    /// Service for managing TimelineEvents
    /// </summary>
    public interface ITimelineService
    {
        /// <summary>
        /// Retrieves a single TimelineEvent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TimelineEvent Get(string id);

        /// <summary>
        /// Retrieves all TimelineEvents sorted by Date
        /// </summary>
        /// <returns></returns>
        IEnumerable<TimelineEvent> GetAll();

        /// <summary>
        /// Inserts or Updates a TimelineEvent
        /// </summary>
        /// <param name="timelineEvent"></param>
        /// <returns></returns>
        TimelineEvent Save(TimelineEvent timelineEvent);

        /// <summary>
        /// Deletes a TimelineEvent
        /// </summary>
        /// <param name="timelineEvent"></param>
        void Delete(TimelineEvent timelineEvent);
    }
}
