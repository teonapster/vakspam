namespace parseJson
{
    public class UserBusinessRating
    {
        public string bid { get; set; }
        public string user_rating { get; set; }
        public string business_avg { get; set; }
        public int business_review_count { get; set; }
        public double bfr { get; set; }
        public string city { get; set; }
        public string[] cat { get; set; }
    }
}