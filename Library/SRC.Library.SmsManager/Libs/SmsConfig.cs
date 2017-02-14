using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.SmsManager.Libs
{
    public class SmsConfig
    {
        public string AccountNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Orginator { get; set; }
        public string ShortNumber { get; set; }

        public Dictionary<int,int> InvalidCharacters { get; set;}
    }
}
