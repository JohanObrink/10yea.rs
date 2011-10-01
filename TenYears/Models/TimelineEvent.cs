using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenYears.Models
{
    /// <summary>
    /// Something important that happened
    /// </summary>
    public class TimelineEvent
    {
        /// <summary>
        /// When it happened
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// When it happened in clear text - like June 21 or The summer of 2001
        /// </summary>
        public string DateHeadline { get; set; }

        /// <summary>
        /// What happened
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// An optional Flickr link
        /// </summary>
        public string Image { get; set; }
    }
}