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
        private const string PASSWORD= "cRM2023px";
        private MemberService.crmegitim _service;
        public ImmibMembers()
        {
            _service = new crmegitim();
        }

        public List<ImmibMember> GetMembers()
        {
            return new List<ImmibMember>()
            {
                new ImmibMember()
                {
                    TCVERNO = "0040490092",
                    UNVAN = "ACAR AKÜ",
                    BIRLIKKOD = 1212,
                    BIRLIK =  "İMMİB.KİMYA"
                }
            };
            //var memberList = _service.Uyelistesi(PASSWORD);
            //DataTable dt = memberList.Tables[0].AsEnumerable().Take(5).CopyToDataTable();
            //return dt.ToList<ImmibMember>();
        }
    }
}
