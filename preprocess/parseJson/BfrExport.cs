using System.Collections.Generic;

namespace parseJson
{
    public class BfrExport : IComparer<BfrExport>
    {
        public string bid { get; set; }
        public double bfr { get; set; }
        public int count { get; set; }
        public string city { get; set; }

        public string[] cat { get; set; }

        public int Compare(BfrExport x, BfrExport y)
        {
            return x.bfr.CompareTo(y.bfr);
        }
    }
}