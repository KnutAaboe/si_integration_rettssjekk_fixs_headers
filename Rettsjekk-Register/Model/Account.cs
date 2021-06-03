using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettsjekk_Register.Model
{
    public class Account
    {

        public class User
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public object lastname { get; set; }
            public string email { get; set; }
            public int customerid { get; set; }
            public int level { get; set; }
            public int changepwd { get; set; }
            public string created_date { get; set; }
            public int insession { get; set; }
            public string lastlogin { get; set; }
        }

        public class TokennUser
        {
            public string auth_token { get; set; }
            public User user { get; set; }
        }

        public class Main
        {
            public bool success { get; set; }
            public TokennUser tokenanduser { get; set; }
        }

    }
}
