using System.Collections.Generic;

namespace parseJson
{
    public class Business : IEqualityComparer<Business>, IComparer<Business>
    {

        public Business()
        {
            ReviewCountHistogram = new int[4000];
        }

        public string business_id { get; set; }

        public string city { get; set; }

        public string[] categories { get; set; }

        public int review_count { get; set; }

        public double AvgRating { get; set; }

        public int[] ReviewCountHistogram { get; set; }

        public bool Equals(Business x, Business y)
        {
            return x.business_id.Equals(y.business_id);
        }

        public int GetHashCode(Business obj)
        {
            return obj.business_id.GetHashCode();
        }

        public int Compare(Business x, Business y)
        {
            return -x.review_count.CompareTo(y.review_count);
        }
    }
}