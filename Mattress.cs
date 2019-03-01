using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Mattress
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profile { get; set; }
        public string feel { get; set; }
        public bool cover { get; set; }
        public string size { get; set; }
        public double weight { get; set; }
        public double pricing { get; set; }
        public string pricingdisplay => "$" + pricing;
        public int year { get; set; }

        public string FullInfo
        {
            get
            {
                // "Cloud Supreme, Soft, 2015, 11"
                return $"{ name } { feel } { year } { profile}";
            }
        }
    }
}
