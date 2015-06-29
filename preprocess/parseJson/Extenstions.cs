using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace parseJson
{
    public static class Extenstions
    {
        public static double Quartile(this List<int> items, int q)
        {
            var a = items.ToArray();
            var result = 0.0;
            Array.Sort(a);

            var i = a.Length * (q / 4.0);
            if (i - (int)i > 0)
            {
                var index = (int)i;
                result = (a[index] + a[index + 1]) / 2.0;
            }
            else
            {
                var index = (int)i;
                result = a[index];
            }

            return result;
        }

        public static void AppendTextS(this RichTextBox c, string text)
        {
            var rt = c;

            if (rt == null) return;

            if (rt.InvokeRequired)
            {
                rt.Invoke(new Action(delegate
                {
                    rt.AppendText(text);
                }));
            }
            else
            {
                rt.AppendText(text);
            }

        }

        public static void AppendTextS(this RichTextBox c, string format, params object[] p)
        {

            if (c.GetType() != typeof(RichTextBox))
            {
                return;
            }

            var rt = c as RichTextBox;

            if (rt.InvokeRequired)
            {
                rt.Invoke(new Action(delegate
                {
                    rt.AppendText(string.Format(format, p));
                }));
            }
            else
            {
                rt.AppendText(string.Format(format, p));
            }

        }

        public static void SetTextS(this Control c, string text)
        {
            var rt = c;

            if (rt == null) return;

            if (rt.InvokeRequired)
            {
                rt.Invoke(new Action(delegate
                {
                    rt.Text = text;
                }));
            }
            else
            {
                rt.Text = text;
            }

        }

        public static void SetTextS(this Control c, string format, params object[] p)
        {

            var rt = c;

            if (rt == null) return;

            if (rt.InvokeRequired)
            {
                rt.Invoke(new Action(delegate
                {
                    rt.Text = string.Format(format, p);
                }));
            }
            else
            {
                rt.Text = string.Format(format, p);
            }

        }

        public static void Safe(this Control c, Action x)
        {
            c.Invoke(x);
        }

        public static double AutoRange(this long mem, out string scale)
        {
            double result = 0;
            int p = 40;
            while (result < 1)
            {
                p = p - 10;
                result = mem / Math.Pow(2, p);
                
            }

            switch (p)
            {
                case 0:
                    scale = "bytes";
                    break;
                case 10:
                    scale = "KBytes";
                    break;
                case 20:
                    scale = "MBytes";
                    break;
                case 30:
                    scale = "GBytes";
                    break;
                default:
                    scale = "";
                    break;
            }
            
            return result;

        }
    }
}