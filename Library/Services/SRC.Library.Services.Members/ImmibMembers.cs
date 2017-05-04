using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Services.Members.MemberService;
using SRC.Library.Data.SqlDao;
using SRC.Library.Entities.CustomEntities;

namespace SRC.Library.Services.Members
{
    public class ImmibMembers
    {
        private const string PASSWORD= "Crmk2012X";
        private MemberService.CariUyeler _service;
        public ImmibMembers()
        {
            _service = new CariUyeler();
        }

        public List<ImmibMember> GetMembers()
        {
            //return new List<ImmibMember>()
            //{
            //    new ImmibMember()
            //    {
            //        TCVERNO = "0040490092",
            //        UNVAN = "ACAR AKÜ",
            //        BIRLIKKOD = 1212,
            //        BIRLIK =  "İMMİB.KİMYA"
            //    }
            //};
            
            var memberList = _service.UyeListesi(PASSWORD);
            DataTable dt = memberList.Tables[0].AsEnumerable().CopyToDataTable();
            return dt.ToList<ImmibMember>();
        }
    }
}
