using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettsjekk_Register.Model
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string lang { get; set; }
        public string phone { get; set; }
        public object web { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public int vatid { get; set; }
        public object logo { get; set; }
        public int price_month { get; set; }
        public int trial { get; set; }
        public int verified { get; set; }
        public object date_verified { get; set; }
        public object verification_code { get; set; }
        public int notify_expiry { get; set; }
        public int expired { get; set; }
        public string create_date { get; set; }
        public string valid_to { get; set; }
        public string api_key { get; set; }
        public int reseller { get; set; }
        public int parent_customer_id { get; set; }
        public object customer_api { get; set; }
        public int invoice_type { get; set; }
        public object monitor_items { get; set; }
        public string customer_type { get; set; }
        
    }
}
