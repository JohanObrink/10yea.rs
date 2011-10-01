using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenYears.Models
{
    /// <summary>
    /// What I've done the last 10 years
    /// </summary>
    public class Testimonial
    {
        /// <summary>
        /// Usually my name
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// The story of my last 10 years
        /// </summary>
        public string Text { get; set; }
    }
}