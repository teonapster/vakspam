using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace parseJson
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<Business, List<Review>> _businessReviewsDictionary = new Dictionary<Business, List<Review>>(new Business());
        private readonly Dictionary<string, Business> _businessIndex = new Dictionary<string, Business>();
        private readonly Dictionary<string, List<Review>> _userReviews = new Dictionary<string, List<Review>>();

        private readonly List<UserReviewExport> _ufrArray = new List<UserReviewExport>();
        private readonly Dictionary<string, UserReviewExport> _ufrIndex = new Dictionary<string, UserReviewExport>();
        private readonly Dictionary<string, BfrExport> _bfrIndex = new Dictionary<string, BfrExport>();

        private string _businesses_json = "N:\\mtpx\\yelp_dataset\\yelp_academic_dataset_business.json";
        private string _reviews_json = "N:\\mtpx\\yelp_dataset\\yelp_academic_dataset_review.json";
        private string _users_json = "N:\\mtpx\\yelp_dataset\\yelp_academic_dataset_user.json";
        private string _processed_json = "N:\\mtpx\\yelp_dataset\\yelp_review_per_business.json";

        private const int ProgressRate = 2500;

        public volatile bool IsAppClosing = false;

        public MainForm()
        {
            InitializeComponent();

            

            var basePath = Application.StartupPath;
            if (File.Exists(Path.Combine(basePath, "processed.json")))
            {
                btnCreateIndex.Enabled = true;
            }

            if (File.Exists(Path.Combine(basePath, "ufb.json")))
            {
                btnCalcUFR.Enabled = true;
            }

            if (File.Exists(Path.Combine(basePath, "bfr.json")))
            {
                btnCalcBFR.Enabled = true;
            }


            ThreadPool.QueueUserWorkItem(x =>
            {
                while (!IsAppClosing)
                {

                    var r1 = "";
                    var r2 = "";
                    var r3 = "";
                    
                    var workingMem = GetMemoryUsage().AutoRange(out r1);
                    var privateMem = Process.GetCurrentProcess().PrivateMemorySize64.AutoRange(out r2);
                    var peakMem = Process.GetCurrentProcess().PeakWorkingSet64.AutoRange(out r3); 

                    statusStrip1.Safe(delegate
                    {
                        lblMemoryUsage.Text = string.Format("Working Memory : {0:N2} {1}", workingMem, r1);
                        lblMemoryUsage1.Text = string.Format("Private Memory : {0:N2} {1}", privateMem, r2);
                        lblPeakMemoryUsage.Text = string.Format("Peak Memory : {0:N2} {1}", privateMem, r3);
                    });
                    

                    Thread.Sleep(1000);
                }
            });
        }

        private void btnParse_Click(object sender, EventArgs e)
        {

            ThreadPool.QueueUserWorkItem(x =>
            {
                output.AppendTextS("Creating index ...");

                using (var reader = new StreamReader(_businesses_json))
                {

                    var i = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var business = JsonConvert.DeserializeObject<Business>(line);
                        _businessReviewsDictionary.Add(business, new List<Review>());
                        _businessIndex.Add(business.business_id, business);

                        i++;
                        if (i % ProgressRate == 0)
                        {
                            var i1 = i;
                            output.AppendTextS(".");
                        }
                    }
                    
                    output.AppendTextS("\ntotal buisnesses : {0}\n", _businessReviewsDictionary.Count);
                    
                }


                using (var reader = new StreamReader(_reviews_json))
                {

                    var i = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var review = JsonConvert.DeserializeObject<Review>(line);
                        var business = _businessIndex[review.business_id];
                        business.AvgRating = (business.AvgRating + review.stars) / 2.0;
                        _businessReviewsDictionary[business].Add(review);

                        i++;
                        if (i % ProgressRate == 0)
                        {
                            output.AppendTextS(".");
                        }
                    }

                    output.AppendTextS(string.Format("\ntotal reviews : {0} \n", i));
                    

                }

                SaveBusinessReviews("processed.json");
                _processed_json = Path.Combine(Application.StartupPath, "processed.json");
                btnCalcUFR.Invoke(new Action(() => btnCalcUFR.Enabled = true ));

            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ThreadPool.QueueUserWorkItem(x =>
            {
                using (var writer = new StreamWriter("outfile.json"))
                {

                    var businesses = _businessReviewsDictionary.Keys.ToArray();
                    Array.Sort(businesses, new Business());


                    var i = 0;
                    foreach (var business in businesses)
                    {

                        var exportRow = new ExportRow();
                        exportRow.Business = business;

                        var reviews = _businessReviewsDictionary[business].ToArray();

                        Array.Sort(reviews, new Review());
                        exportRow.Reviews = reviews;

                        var s = JsonConvert.SerializeObject(exportRow);
                        writer.WriteLine(s);
                        i++;
                        if (i % ProgressRate == 0)
                        {
                            var i1 = i;
                            output.Invoke(new Action(
                                delegate { output.AppendText("."); }
                            ));
                        }
                    }
                    output.Invoke(new Action(
                        delegate { output.AppendText(string.Format("total ... {0}\n", i)); }
                        ));
                }


            });
        }

        private void btnFindSpamUsers_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {

                _businessReviewsDictionary.Clear();


                var logger = new StreamWriter("out.all.txt");

                using (var reader = new StreamReader(_processed_json))
                {

                    var i = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var row = JsonConvert.DeserializeObject<ExportRow>(line);

                        _businessReviewsDictionary.Add(row.Business, row.Reviews.ToList());

                        i++;
                        if (i % ProgressRate == 0)
                        {
                            var i1 = i;
                            output.Invoke(new Action(
                                delegate { output.AppendText("."); }
                            ));
                        }



                        using (var writer = new StreamWriter(string.Format("out-{0}.csv", i)))
                        {

                            writer.WriteLine(row.Business.business_id);


                            var items = new List<int>();

                            foreach (var source in row.Reviews.GroupBy(r => r.date))
                            {

                                var count = source.Count(r => r.stars == 5);

                                writer.WriteLine("{0}, {1}", source.Key, count);
                                items.Add(count);


                            }


                            if (items.Count() <= 4)
                                break;

                            var q1 = items.Quartile(1);
                            var q2 = items.Quartile(2);
                            var q3 = items.Quartile(3);

                            var iqr = q3 - q1;
                            var uof = q3 + 3 * iqr;
                            var uif = q3 + 1.5 * iqr;


                            Console.WriteLine("UOF:{0}, Q1:{1}, Q3:{2}", uof, q1, q3);
                            logger.WriteLine("UOF:{0}, Q1:{1}, Q3:{2}", uof, q1, q3);

                            foreach (var source in row.Reviews.GroupBy(r => r.date))
                            {
                                //if (source.Count() > uif)
                                //{
                                //    Console.WriteLine(string.Format("-- {0} - {1}", source.Key, source.Count()));
                                //}
                                var count = source.Count(r => r.stars == 5);
                                if (count > uof)
                                {
                                    Console.WriteLine("*** {0} - {1} - {2}", row.Business.business_id, source.Key, source.Count());
                                    logger.WriteLine("*** {0} - {1} - {2}", row.Business.business_id, source.Key, count);
                                }
                            }

                            writer.Close();
                        }

                        if (row.Reviews.Count() < 50)
                            break;


                        if (i > 50) break;
                    }

                    output.Invoke(new Action(delegate
                    {
                        output.AppendText(string.Format("total buisnesses : {0} \n", _businessReviewsDictionary.Count));
                    }));
                }

                logger.Close();

            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {

                var logger = new StreamWriter("out.all.txt");
                LoadBusinessIndex(_processed_json);

                LoadUserReviews(_reviews_json);
                

                using (var writer = new StreamWriter("test.out.json"))
                {
                    foreach (var userReview in _userReviews)
                    {
                        var ratings = new List<UserBusinessRating>();

                        foreach (var user_reviews in userReview.Value)
                        {
                            ratings.Add(new UserBusinessRating
                            {
                                user_rating = user_reviews.stars.ToString(),
                                business_avg = _businessIndex[user_reviews.business_id].AvgRating.ToString()
                            });
                        }

                        var obj = new UserReviewExport
                        {
                            uid = userReview.Key,
                            count = userReview.Value.Count,
                            rating = ratings.ToArray()
                        };

                        var line = JsonConvert.SerializeObject(obj);
                        writer.WriteLine(line);
                    }
                }

                output.Invoke(new Action(
                               delegate { output.AppendText("done."); }
                           ));



                logger.Close();

            });
        }

        private void btnCalcUFR_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                var i = 0;

                _businessIndex.Clear();

                LoadBusinessIndex(_processed_json);
                LoadUserReviews(_reviews_json);

                output.AppendTextS("Calculating UFR ...");

                i = 0;
                foreach (var userReview in _userReviews)
                {
                    var ratings = new List<UserBusinessRating>();
                   
                    var sum = 0.0;
                    foreach (var user_reviews in userReview.Value)
                    {

                        var tb = _businessIndex[user_reviews.business_id];

                        if (user_reviews.stars == 5 || user_reviews.stars == 1)
                        {
                            sum += 3 * Math.Abs(tb.AvgRating - user_reviews.stars);
                        }
                        else if (user_reviews.stars == 4 || user_reviews.stars == 2)
                        {
                            sum += 1.5 * Math.Abs(tb.AvgRating - user_reviews.stars);
                        }
                        else
                        {
                            sum += Math.Abs(tb.AvgRating - user_reviews.stars);
                        }

                        ratings.Add(new UserBusinessRating
                        {
                            user_rating = user_reviews.stars.ToString(),
                            business_avg = Math.Round(tb.AvgRating, 4,MidpointRounding.AwayFromZero).ToString(),
                            business_review_count = tb.review_count,
                            bid = user_reviews.business_id
                        });
                    }

                    var obj = new UserReviewExport
                    {
                        uid = userReview.Key,
                        count = userReview.Value.Count,
                        rating = ratings.ToArray(),
                        ufr = Math.Round(sum / userReview.Value.Count,4, MidpointRounding.AwayFromZero)
                    };
                    
                    _ufrArray.Add(obj);
                    i++;
                    if (i % ProgressRate == 0)
                    {
                        var i1 = i;
                        output.AppendTextS(".");
                    }
                }

                output.AppendTextS("\ndone.\n");
                output.AppendTextS("Saving ufr.json ...");
                using (var writer = new StreamWriter("ufr.json"))
                {
                    i = 0;
                    var a = _ufrArray.ToArray();
                    Array.Sort(a, new UserReviewExport());

                    foreach (var userReviewExport in a)
                    {
                        var line = JsonConvert.SerializeObject(userReviewExport);
                        writer.WriteLine(line);

                        i++;
                        if (i % ProgressRate == 0)
                        {
                            output.AppendTextS(".");
                        }
                    }
                }
                output.AppendTextS("\ndone.\n");
                btnCalcBFR.Invoke(new Action(() => btnCalcBFR.Enabled = true));
            });
        }

        private void btnCalcBFR_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                LoadBusinessReviews(_processed_json, true);
                LoadUFR("ufr.json");

                var bfr_array = new List<BfrExport>();

                output.AppendTextS("Calculating BFR ...");

                foreach (var business in _businessIndex.Values)
                {

                    var sum = 0.0;
                    foreach (var reviews in _businessReviewsDictionary[business])
                    {
                        sum += _ufrIndex[reviews.user_id].ufr;
                    }


                    var tb = _businessReviewsDictionary[business];


                    var bfr = 0.0;
                    if (tb.Count > 0)
                        bfr = Math.Round(sum/tb.Count, 4, MidpointRounding.AwayFromZero);
                    
                    bfr_array.Add(new BfrExport
                    {
                        bid = business.business_id,
                        bfr = bfr ,
                        count = tb.Count,
                        city = business.city,
                        cat = business.categories
                    });

                }


                var sorted_array = bfr_array.ToArray();
                Array.Sort(sorted_array, new BfrExport());
                output.AppendTextS("\ndone.\n");
                output.AppendTextS("Saving bfr.json ...");
                using (var writer = new StreamWriter("bfr.json"))
                {

                    var i = 0;
                    foreach (var bfrExport in sorted_array)
                    {
                        var line = JsonConvert.SerializeObject(bfrExport);
                        writer.WriteLine(line);
                        i++;
                        if (i % ProgressRate == 0) output.AppendTextS(".");
                    }
                }

                output.AppendTextS("\ndone.\n");

                
                btnMerge.Invoke(new Action(() => btnMerge.Enabled = true));
            });
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                //LoadBusinessReviews(_processed_json, true);
                LoadUFR("ufr.json");
                LoadBFR("bfr.json");

                var merged = new UserReviewExport();


                var mergedIndex = new Dictionary<string,UserReviewExport>();
                output.AppendTextS("Merging ...");

                var count = 0;
                foreach (var ufr in _ufrIndex.Values)
                {

                    var mt = new UserReviewExport
                    {
                        ufr = ufr.ufr,
                        uid = ufr.uid,
                        count = ufr.count,
                        rating = new UserBusinessRating[ufr.rating.Length]
                    };



                    for(var i=0; i < ufr.rating.Length;i++)
                    {

                        var tb = _bfrIndex[ufr.rating[i].bid];

                        mt.rating[i] = new UserBusinessRating
                        {
                            bid = ufr.rating[i].bid,
                            business_review_count = ufr.rating[i].business_review_count,
                            business_avg = ufr.rating[i].business_avg,
                            user_rating = ufr.rating[i].user_rating,
                            cat = tb.cat,
                            bfr = tb.bfr,
                            city = tb.city
                        };
                    }

                    mergedIndex.Add(ufr.uid, mt);
                    count++;
                    if (count%ProgressRate == 0)
                    {
                        output.AppendTextS(".");
                    }
                }
                output.AppendTextS("\ndone.\n");
                output.AppendTextS("Saving merged.json ...");
                using (var writer = new StreamWriter("merged.json"))
                {

                    var i = 0;
                    foreach (var bfrExport in mergedIndex.Values)
                    {
                        var line = JsonConvert.SerializeObject(bfrExport);
                        writer.WriteLine(line);
                        i++;
                        if (i % ProgressRate == 0) output.AppendTextS(".");
                    }
                }

                output.AppendTextS("\ndone.\n");
            });
        }
        
        private void LoadBusinessReviews(string filename, bool createIndex = false)
        {

            output.AppendTextS("loading {0} ...", filename);
            _businessReviewsDictionary.Clear();
            if (createIndex) _businessIndex.Clear();
            using (var reader = new StreamReader(filename))
            {
                var i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = JsonConvert.DeserializeObject<ExportRow>(line);

                    _businessReviewsDictionary.Add(row.Business, row.Reviews.ToList());

                    if (createIndex)
                    {
                        _businessIndex.Add(row.Business.business_id, row.Business);
                    }

                    i++;
                    if (i % ProgressRate == 0) { output.AppendTextS("."); }    
                }

                output.AppendTextS(string.Format("\nloaded. {0} rows\n",i));
            }
        }

        private void LoadBusinessIndex(string filename)
        {
            output.AppendTextS("loading {0} ...", filename);
            _businessIndex.Clear();
            using (var reader = new StreamReader(filename))
            {
                var i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = JsonConvert.DeserializeObject<ExportRow>(line);
                    
                    _businessIndex.Add(row.Business.business_id, row.Business);

                    i++;
                    if (i % ProgressRate == 0) { output.AppendTextS("."); }
                }

                output.AppendTextS(string.Format("\nloaded ... {0} rows\n", i));
            }
        }

        private void LoadUserReviews(string filename)
        {
            output.AppendTextS("loading {0} ...", filename);
            _userReviews.Clear();
            using (var reader = new StreamReader(filename))
            {
                var i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = JsonConvert.DeserializeObject<Review>(line);

                    if (!_userReviews.ContainsKey(row.user_id))
                    {
                        _userReviews.Add(row.user_id, new List<Review>());
                    }

                    _userReviews[row.user_id].Add(row);

                    i++;
                    if (i % ProgressRate == 0) { output.AppendTextS("."); }
                }
                output.AppendTextS(string.Format("\nloaded ... {0} rows\n", i));
            }
            
        }
        
        private void LoadUFR(string filename)
        {
            output.AppendTextS("loading {0} ...",filename);
            _ufrIndex.Clear();
            using (var reader = new StreamReader(filename))
            {
                var i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = JsonConvert.DeserializeObject<UserReviewExport>(line);
                    _ufrIndex.Add(row.uid, row);
                    
                    i++;
                    if (i % ProgressRate == 0) { output.AppendTextS("."); }
                }

                output.AppendTextS("\nloaded {0} rows\n", i);
            }


        }

        private void LoadBFR(string filename)
        {
            _bfrIndex.Clear();
            using (var reader = new StreamReader(filename))
            {
                var i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = JsonConvert.DeserializeObject<BfrExport>(line);
                    _bfrIndex.Add(row.bid, row);

                    i++;
                    if (i % ProgressRate == 0) { output.AppendTextS("."); }
                }

                output.AppendTextS("\nloaded {0} rows\n", i);
            }
        }
        
        private void SaveBusinessReviews(string filename)
        {

            output.AppendTextS("Saving {0} ...", filename);

            using (var writer = new StreamWriter(filename))
            {

                var businesses = _businessReviewsDictionary.Keys.ToArray();
                Array.Sort(businesses, new Business());

                var i = 0;
                foreach (var business in businesses)
                {

                    var exportRow = new ExportRow();
                    exportRow.Business = business;

                    var reviews = _businessReviewsDictionary[business].ToArray();

                    Array.Sort(reviews, new Review());
                    exportRow.Reviews = reviews;

                    var s = JsonConvert.SerializeObject(exportRow);
                    writer.WriteLine(s);
                    i++;
                    if (i % ProgressRate == 0)
                    {
                        var i1 = i;
                        output.AppendTextS(".");
                    }
                }
                output.AppendTextS("\ntotal rows : {0} written\n", i); 
            }
        }

        private void setInputFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FormSelectInputFiles();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(f.txtBusinessFile.Text) &&
                    File.Exists(f.txtReviewsFile.Text) &&
                    File.Exists(f.txtUsersFile.Text))
                {

                    _businesses_json = f.txtBusinessFile.Text;
                    lblBusinessFile.Text = _businesses_json;

                    _reviews_json = f.txtReviewsFile.Text;
                    lblReviewsFiles.Text = _reviews_json;

                    _users_json = f.txtUsersFile.Text;
                    lblUsersFile.Text = _users_json;
                }

                btnCreateIndex.Enabled = true;
              
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private long GetMemoryUsage()
        {
            return Process.GetCurrentProcess().WorkingSet64;
        }

        private void LockButtons()
        {
           
        }
        private void UnlockButtons()
        {
           
        }

    }
}
