using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CustomEntities
{
    public class ImmibMember
    {
        public string UNVAN { get; set; }
        public decimal? BIRLIKKOD { get; set; }
        public string BIRLIK { get; set; }
        public DateTime GIRIS_TARIHI { get; set; }
        public DateTime CIKIS_TARIHI { get; set; }
        public string SICIL_NO { get; set; }
        public string TCVERNO { get; set; }
    }
}
