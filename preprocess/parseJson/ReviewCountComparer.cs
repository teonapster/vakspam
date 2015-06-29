using System.Collections.Generic;

namespace parseJson
{
    public class ReviewCountComparer : IComparer<Review>
    {

        public int Compare(Review x, Review y)
        {
            return x.stars.CompareTo(y.stars);
        }
    }
}