using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettsjekk_Register.Data
{
    public class Trials
    {
        public class Solvent
        {
            public string trial_date { get; set; }
            public string trial_summary { get; set; }
            public string trial_parties { get; set; }
            public string trial_type { get; set; }
            public string case_type { get; set; }
            public string role { get; set; }
            public int status { get; set; }
            public string updated_at { get; set; }
        }

        public class Bankruptcy
        {
            public string company_name { get; set; }
            public string reg_date { get; set; }
            public string case_details { get; set; }
        }

        public class Trial
        {
            public string trial_date { get; set; }
            public string trial_summary { get; set; }
            public string trial_parties { get; set; }
            public string trial_reference { get; set; }
            public string trial_type { get; set; }
            public string case_type { get; set; }
            public string role { get; set; }
            public string foretaksreg { get; set; }
        }

        public class Data
        {
            public List<Trial> trials { get; set; }
            public List<Bankruptcy> bankruptcies { get; set; }
            public List<Solvent> solvent { get; set; }
        }


    }
}
