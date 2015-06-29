using System;
using System.Collections.Generic;
using System.Globalization;

namespace parseJson
{
    public class Review : IComparer<Review>
    {
        public string user_id { get; set; }
        public string review_id { get; set; }
        public int stars { get; set; }
        public string date { get; set; }
        public string type { get; set; }
        public string business_id { get; set; }

        public int Compare(Review x, Review y)
        {

            var date1 = DateTime.ParseExact(x.date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var date2 = DateTime.ParseExact(y.date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return date1.CompareTo(date2);
        }
    }
}