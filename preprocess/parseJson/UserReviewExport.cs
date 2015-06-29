using System.Collections.Generic;

namespace parseJson
{
    public class UserReviewExport : IComparer<UserReviewExport>
    {
        public string uid { get; set; }
        public int count { get; set; }
        public UserBusinessRating[] rating { get; set; }

        public double ufr { get; set; }

        public int Compare(UserReviewExport x, UserReviewExport y)
        {
            return x.ufr.CompareTo(y.ufr);
        }
    }
}