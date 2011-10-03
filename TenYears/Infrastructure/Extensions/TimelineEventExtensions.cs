using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenYears.Models;

namespace TenYears.Infrastructure.Extensions
{
    public static class TimelineEventExtensions
    {
        public static string Headline(this TimelineEvent tle)
        {
            if (!string.IsNullOrWhiteSpace(tle.DateHeadline))
                return string.Format("{0} {1}", tle.DateHeadline, tle.Date.Year);
            else
                return tle.Date.ToLocalTime().ToLongDateString();
        }
    }
}