using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenYears.Models
{
    /// <summary>
    /// Me who is telling the story
    /// </summary>
    public class Person
    {
        /// <summary>
        /// My Id in the db
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// My name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A link to my photo
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// A URL to a video on YouTube
        /// </summary>
        public string Video { get; set; }

        /// <summary>
        /// My testimonial
        /// </summary>
        public Testimonial Testimonial { get; set; }

        /// <summary>
        /// My id on Facebook
        /// </summary>
        public string FacebookId { get; set; }

        /// <summary>
        /// My handle on Twitter
        /// </summary>
        public string TwitterHandle { get; set; }

        /// <summary>
        /// My id on Google+
        /// </summary>
        public string GooglePlusId { get; set; }
    }
}