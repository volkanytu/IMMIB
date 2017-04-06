using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Business.Interfaces;
using SRC.Library.Services.Members.MemberService;
using SRC.Library.Data.SqlDao;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Services.Members;

namespace SRC.ConsoleApp.ScheduledJobs.Jobs
{
    public class ImmibMemberIntegration: BaseJob
    {
        private ImmibMembers _service;
        private ILogManager _logmanager;
        private IAccountBusiness _accountBusiness;
        private IBaseBusiness<Account> _baseBusiness;

        public ImmibMemberIntegration(ILogManager logmanager, IBaseBusiness<Account> baseBusiness, IAccountBusiness accountBusiness)
        {
            _service = new ImmibMembers(); //Bunu ioc'ye taşımalı mıyız?
            _accountBusiness = accountBusiness;
            _baseBusiness = baseBusiness;
            _logmanager = logmanager;
        }
        protected override void DoWork(string[] args)
        {
            List<ImmibMember> members = _service.GetMembers();

            foreach (var immibMember in members)
            {
                Account account = _accountBusiness.GetAccount(immibMember.TCVERNO);
                if (account == null)
                {
                    //immibmember to account
                    _baseBusiness.Insert(account);
                }
            }
        }
    }
}
